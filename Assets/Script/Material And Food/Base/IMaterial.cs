using UnityEngine;

namespace Assets.Script.Material_And_Food.Base
{
    public interface IMaterial
    {
        // Các Material sẽ có những sau đây
        Transform Get_Transform(); // Có Lệnh Get_Transform để có thể trả về các TransForm của các IMaterial (Trees, Rocks, Gold)
        void Get_Button_Down();
    }
}
