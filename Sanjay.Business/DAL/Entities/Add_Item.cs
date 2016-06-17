using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Items.Business.DAL.Entities
{
    public class Add_Item
    {
        #region id
  
        [Key]
        public int Id { get; set; }

        #endregion

        #region name

        [MaxLength(200)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        #endregion

        #region Desc

        public string Desc { get; set; }

        #endregion
    }
}