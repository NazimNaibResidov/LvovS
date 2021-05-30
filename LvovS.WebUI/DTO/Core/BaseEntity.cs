using System.ComponentModel.DataAnnotations;

namespace LvovS.WebUI.DTO.Core
{
    public abstract class BaseEntity<T>
    {
        [Key]
        public virtual T Id { get; set; }
    }

    public abstract class BaseDto<T>
    {
        public virtual T Id { get; set; }
    }
}