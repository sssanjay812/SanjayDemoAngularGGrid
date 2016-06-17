using System.Runtime.Serialization;
using Items.Business.DAL.Entities;
using Utils.Web;

namespace Items.Web.ViewModels
{
    [DataContract]
    public class ADD_ItemViewModel : BaseValidatableViewModel<ADD_ItemViewModel, Add_Item>
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Desc { get; set; }
    }
}