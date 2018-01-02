using Models.DataTable;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interface.BLL
{
    public interface IDT_UserService : IBllService<DT_User>
    {
        DT_User Insert();

        List<DT_User> GetList();
    }
}
