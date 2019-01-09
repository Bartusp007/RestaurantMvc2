using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RestaurantMvc.ViewModel.ViewModels;

namespace RestaurantMvc.ViewModel.ValidationAttribute
{
    public class MinDateReservationAttribute:System.ComponentModel.DataAnnotations.ValidationAttribute
    {
        private readonly string _maxDate;
        

        public MinDateReservationAttribute(string maxDate)
        {
            _maxDate = maxDate;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (validationContext.ObjectInstance.GetType() != typeof(ReservationViewModel))
                throw new TypeAccessException();
            var typeData = typeof(ReservationViewModel);
            var propertyAccessor = typeData.GetProperty(_maxDate);
            var maxDate = (TimeSpan) propertyAccessor.GetValue(validationContext.ObjectInstance);
            return (TimeSpan)value>maxDate ? new ValidationResult(FormatErrorMessage(validationContext.DisplayName)) : ValidationResult.Success;
        }
    }

    public class MaxDateReservationAttribute : System.ComponentModel.DataAnnotations.ValidationAttribute
    {
        private readonly string _minDate;

        public MaxDateReservationAttribute(string minDate)
        {
            _minDate = minDate;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (validationContext.ObjectInstance.GetType()!= typeof(ReservationViewModel))
            throw new TypeAccessException();

            var typeData = typeof(ReservationViewModel);
            var propertyAccess = typeData.GetProperty(_minDate);
            var mindate = (TimeSpan) propertyAccess.GetValue(validationContext.ObjectInstance);
            return (TimeSpan)value<mindate ? new ValidationResult(FormatErrorMessage(validationContext.DisplayName)) : ValidationResult.Success;

        }
    }
}