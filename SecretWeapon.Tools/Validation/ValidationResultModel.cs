using FluentValidation.Results;

namespace SecretWeapon.Tools.Validation
{
    public class ValidationResultModel<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public T DeEntity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ValidationResult DeValidationResult { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="validationResult"></param>
        public ValidationResultModel(T entity, ValidationResult validationResult)
        {
            DeEntity = entity;
            DeValidationResult = validationResult;
        }
    }
}
