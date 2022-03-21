using System.ComponentModel.DataAnnotations;
using ReactiveUI;

namespace Psychologist.Core.Repository.Entities
{
    public class BaseEntity:ReactiveObject
    {
        [Key]
        public int Id { get; set; }
    }
}