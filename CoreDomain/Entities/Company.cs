﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace CoreContext.Models;

public partial class Company
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreateOn { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? CreateSource { get; set; }

    public DateTime? UpdateOn { get; set; }

    public Guid? UpdateBy { get; set; }

    public Guid? UpdateReason { get; set; }

    public DateTime? DeleteOn { get; set; }

    public Guid? DeleteBy { get; set; }

    public Guid? DeleteReason { get; set; }

    public bool IsDeleted { get; set; }

    public virtual User? CreateByNavigation { get; set; }

    public virtual Source? CreateSourceNavigation { get; set; }

    public virtual User? DeleteByNavigation { get; set; }

    public virtual Reason? DeleteReasonNavigation { get; set; }

    public virtual User? UpdateByNavigation { get; set; }

    public virtual Reason? UpdateReasonNavigation { get; set; }
}