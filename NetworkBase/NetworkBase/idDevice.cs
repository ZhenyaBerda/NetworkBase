//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NetworkBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class idDevice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public idDevice()
        {
            this.networks = new HashSet<network>();
            this.userInfoes = new HashSet<userInfo>();
        }
    
        public int deviceID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    
        public virtual Feature Feature { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<network> networks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<userInfo> userInfoes { get; set; }
    }
}
