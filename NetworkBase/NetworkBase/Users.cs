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
    
    public partial class Users
    {
        public int userID { get; set; }
        public string userLogin { get; set; }
        public string userPassword { get; set; }
        public string userAccount { get; set; }
    
        public virtual Devices Devices { get; set; }
    }
}