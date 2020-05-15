using FluentValidation.Results;

namespace SecretWeapon.Tools.Validation
{
    public class ValidationResultModel<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public T Entity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ValidationResult ValidationResult { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="validationResult"></param>
        public ValidationResultModel(T entity, ValidationResult validationResult)
        {
            Entity = entity;
            ValidationResult = validationResult;
        }
    }
}
