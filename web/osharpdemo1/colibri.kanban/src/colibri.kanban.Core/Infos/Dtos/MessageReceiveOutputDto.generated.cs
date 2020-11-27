// -----------------------------------------------------------------------
// <auto-generated>
//    此代码由代码生成器生成。
//    手动更改此文件可能导致应用程序出现意外的行为。
//    如果重新生成代码，对此文件的任何修改都会丢失。
//    如果需要扩展此类：可遵守如下规则进行扩展：
//      1.横向扩展：如需添加额外的属性，可新建文件“MessageReceiveOutputDto.cs”的分部类“public partial class MessageReceiveOutputDto”}添加属性
// </auto-generated>
//
//  <copyright file="MessageReceiveOutputDto.generated.cs" company="OSharp开源团队">
//      Copyright (c) 2014-2019 Liuliu. All rights reserved.
//  </copyright>
//  <site>https://www.osharp.org</site>
//  <last-editor>郭明锋</last-editor>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using OSharp.Entity;
using OSharp.Mapping;

using colibri.kanban.Infos.Entities;
using colibri.kanban.Identity.Dtos;

namespace colibri.kanban.Infos.Dtos
{
    /// <summary>
    /// 输入DTO：站内信接收记录信息
    /// </summary>
    [MapFrom(typeof(MessageReceive))]
    [Description("站内信接收记录信息")]
    public partial class MessageReceiveOutputDto : IOutputDto, IDataAuthEnabled
    {
        /// <summary>
        /// 初始化一个<see cref="MessageReceiveOutputDto"/>类型的新实例
        /// </summary>
        public MessageReceiveOutputDto()
        { }

        /// <summary>
        /// 初始化一个<see cref="MessageReceiveOutputDto"/>类型的新实例
        /// </summary>
        public MessageReceiveOutputDto(MessageReceive entity)
        {
            Id = entity.Id;
            ReadDate = entity.ReadDate;
            NewReplyCount = entity.NewReplyCount;
            MessageId = entity.MessageId;
            UserId = entity.UserId;
            CreatedTime = entity.CreatedTime;
        }

        /// <summary>
        /// 获取或设置 编号
        /// </summary>
        [DisplayName("编号")]
        public Guid Id { get; set; }

        /// <summary>
        /// 获取或设置 接收时间
        /// </summary>
        [DisplayName("接收时间")]
        public DateTime ReadDate { get; set; }

        /// <summary>
        /// 获取或设置 新回复数，接收者使用
        /// </summary>
        [DisplayName("新回复数，接收者使用")]
        public int NewReplyCount { get; set; }

        /// <summary>
        /// 获取或设置 接收的主消息编号
        /// </summary>
        [DisplayName("接收的主消息编号")]
        public Guid MessageId { get; set; }

        /// <summary>
        /// 获取或设置 消息接收人编号
        /// </summary>
        [DisplayName("消息接收人编号")]
        public int UserId { get; set; }

        /// <summary>
        /// 获取或设置 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 获取或设置 是否可更新的数据权限状态
        /// </summary>
        public bool Updatable { get; set; }

        /// <summary>
        /// 获取或设置 是否可删除的数据权限状态
        /// </summary>
        public bool Deletable { get; set; }

    }
}