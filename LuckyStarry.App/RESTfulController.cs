using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LuckyStarry.App
{
    /// <summary>
    /// 默认的带有数据库服务的 框架 WebApi 控制器，集成了可对指定实体表进行操作的服务方法。
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public abstract class RESTfulController<TEntity> : Controller
        where TEntity : Models.IEntity
    {
        private readonly Services.IDbService<TEntity> service;

        protected RESTfulController(Services.IDbService<TEntity> service) => this.service = service;
        /// <summary>
        /// 默认的 Get 方法实现，用来获取实体表中的全部数据，并以 { isSuccess : Boolean, message : String, entity : { count : Int32, list : T[] } } 类型返回。
        /// </summary>
        /// <returns>JsonSmart结构的响应结果</returns>
        public virtual Models.JsonSmart Get()
        {
            var list = this.service.GetAll();
            return Models.JsonSmart.Successful(new { count = list?.Count() ?? 0, list = list });
        }
    }
    /// <summary>
    /// 默认的带有数据库服务的 框架 WebApi 控制器，集成了可对带有指定主键类型的指定实体表进行操作的服务方法。
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TPrimary">实体主键类型</typeparam>
    public abstract class RESTfulController<TEntity, TPrimary> : RESTfulController<TEntity>
        where TEntity : Models.IEntity<TPrimary>
        where TPrimary : struct
    {
        private readonly Services.IDbService<TEntity, TPrimary> service;

        protected RESTfulController(Services.IDbService<TEntity, TPrimary> service) : base(service) => this.service = service;
        /// <summary>
        /// 根据主键获取实体记录，并以 { isSuccess : Boolean, message : String, entity : T } 类型返回。
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns>JsonSmart结构的响应结果</returns>
        public virtual Models.JsonSmart GetById(TPrimary id)
        {
            var entity = this.service.GetById(id);
            if (entity != null)
            {
                return Models.JsonSmart.Successful(entity);
            }
            else
            {
                return Models.JsonSmart.Failed($"未查询到id为[{ id }]的数据");
            }
        }
        /// <summary>
        /// 向实体表中插入一条数据，并将插入的记录以 { isSuccess : Boolean, message : String, entity : T } 类型返回。
        /// </summary>
        /// <param name="model">要插入实体表的实体数据</param>
        /// <returns>JsonSmart结构的响应结果</returns>
        public virtual Models.JsonSmart PutSave(TEntity model)
        {
            if (model == null)
            {
                return Models.JsonSmart.Failed("未指定要保存的资源内容");
            }
            var id = this.service.Insert(model);
            if (!id.Equals(default(TPrimary)))
            {
                return this.GetById(id);
            }
            else
            {
                return Models.JsonSmart.Failed();
            }
        }
        /// <summary>
        /// 更新实体表中指定ID的数据，并将更新后的记录以 { isSuccess : Boolean, message : String, entity : T } 类型返回。
        /// </summary>
        /// <param name="id">要更新的实体的主键ID</param>
        /// <param name="model">更新的实体内容</param>
        /// <returns>JsonSmart结构的响应结果</returns>
        public virtual Models.JsonSmart PostUpdate(TPrimary id, [FromBody] TEntity model)
        {
            if (model == null)
            {
                return Models.JsonSmart.Failed("未指定要更新的资源内容");
            }
            model.ID = id;

            var result = this.service.Update(model);
            if (result)
            {
                return this.GetById(id);
            }
            else
            {
                return Models.JsonSmart.Failed();
            }
        }
    }
}
