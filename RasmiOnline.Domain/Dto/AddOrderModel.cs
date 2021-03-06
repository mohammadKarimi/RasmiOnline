﻿using RasmiOnline.Domain.Enum;
using RasmiOnline.Domain.Properties;
using System;
using System.ComponentModel.DataAnnotations;

namespace RasmiOnline.Domain.Dto
{
    public class AddOrderModel
    {
        [Display(Name = nameof(DisplayName.FirstName), ResourceType = typeof(DisplayName))]
        [Required(ErrorMessageResourceName = nameof(ErrorMessage.Required), ErrorMessageResourceType = typeof(ErrorMessage))]
        [MaxLength(25, ErrorMessageResourceName = nameof(ErrorMessage.MaxLength), ErrorMessageResourceType = typeof(ErrorMessage))]
        [StringLength(25, ErrorMessageResourceName = nameof(ErrorMessage.MaxLength), ErrorMessageResourceType = typeof(ErrorMessage))]
        public string FirstName { get; set; }

        public byte DayToDeliver { get; set; }

        [Display(Name = nameof(DisplayName.LastName), ResourceType = typeof(DisplayName))]
        [Required(ErrorMessageResourceName = nameof(ErrorMessage.Required), ErrorMessageResourceType = typeof(ErrorMessage))]
        [MaxLength(30, ErrorMessageResourceName = nameof(ErrorMessage.MaxLength), ErrorMessageResourceType = typeof(ErrorMessage))]
        [StringLength(30, ErrorMessageResourceName = nameof(ErrorMessage.MaxLength), ErrorMessageResourceType = typeof(ErrorMessage))]
        public string LastName { get; set; }

        [RegularExpression(@"^0?9\d{9}$", ErrorMessageResourceName = nameof(ErrorMessage.InvalidMobileNumber), ErrorMessageResourceType = typeof(ErrorMessage))]
        [Display(Name = nameof(DisplayName.MobileNumber), ResourceType = typeof(DisplayName))]
        [Required(ErrorMessageResourceName = nameof(ErrorMessage.Required), ErrorMessageResourceType = typeof(ErrorMessage))]

        public string MobileNumber { get; set; }

       // [Required(ErrorMessageResourceName = nameof(ErrorMessage.Required), ErrorMessageResourceType = typeof(ErrorMessage))]
        [Display(Name = nameof(DisplayName.Email), ResourceType = typeof(DisplayName))]
        [EmailAddress(ErrorMessageResourceName = nameof(ErrorMessage.Email), ErrorMessageResourceType = typeof(ErrorMessage))]
        [MaxLength(50, ErrorMessageResourceName = nameof(ErrorMessage.MaxLength), ErrorMessageResourceType = typeof(ErrorMessage))]
        [StringLength(50, ErrorMessageResourceName = nameof(ErrorMessage.MaxLength), ErrorMessageResourceType = typeof(ErrorMessage))]
        public string Email { get; set; }

        [Display(Name = nameof(DisplayName.Description), ResourceType = typeof(DisplayName))]
        [MaxLength(500, ErrorMessageResourceName = nameof(ErrorMessage.MaxLength), ErrorMessageResourceType = typeof(ErrorMessage))]
        [StringLength(500, ErrorMessageResourceName = nameof(ErrorMessage.MaxLength), ErrorMessageResourceType = typeof(ErrorMessage))]
        public string Description { get; set; }

        [Display(Name = nameof(DisplayName.PassportIsAttached), ResourceType = typeof(DisplayName))]
        public bool WithPassport { get; set; }

        public Guid UserId { get; set; }

        [Display(Name = nameof(DisplayName.TranslateType), ResourceType = typeof(DisplayName))]
        public TranslateType TranslateType { get; set; }

        public OrderStatus Status { get; set; }
    }
}
