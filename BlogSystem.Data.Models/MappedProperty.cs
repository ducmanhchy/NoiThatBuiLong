using System.Collections.Generic;
using System.Linq;

namespace BlogSystem.Data.Models
{
    public static class MappedProperty
    {
        public static readonly List<EntityMappedType> PostTypes = new List<EntityMappedType>(){
            new EntityMappedType { Key = "GT-L-DESIGN", Value = "Thiết kế img-left", Unit = "TK"},
            new EntityMappedType { Key = "GT-R-DESIGN", Value = "Thiết kế img-right", Unit = "TK"},
            new EntityMappedType { Key = "SL_HOME", Value = "Slide - Trang chủ", Unit = "HOME"},
            new EntityMappedType { Key = "BN_HOME", Value = "Banner - Trang chủ", Unit = "HOME"},
            new EntityMappedType { Key = "PL_HOME", Value = "Sản phẩm nội bật - Trang chủ", Unit = "HOME"},
            new EntityMappedType { Key = "VD_HOME", Value = "Video - Trang chủ", Unit = "HOME"},
            new EntityMappedType { Key = "PK", Value = "Phòng khách - Phòng", Unit = "RM"},
            new EntityMappedType { Key = "PA", Value = "Phòng ăn - Phòng", Unit = "RM"},
            new EntityMappedType { Key = "PN", Value = "Phòng ngủ - Phòng", Unit = "RM"},
            new EntityMappedType { Key = "PLV", Value = "Phòng khách - Phòng", Unit = "RM"},
            new EntityMappedType { Key = "TB", Value = "Tủ bếp - Phòng", Unit = "RM"},
            new EntityMappedType { Key = "HTT", Value = "Hàng trang trí - Phòng", Unit = "RM"},
            new EntityMappedType { Key = "TT", Value = "Thông tin", Unit = "FT"},
            new EntityMappedType { Key = "DVKH", Value = "Dịch Vụ Khách Hàng", Unit = "FT"}
        };
        public static readonly List<EntityMappedType> MenuTypes = new List<EntityMappedType>(){
            new EntityMappedType { Key = "YT", Value = "Ý Tưởng"},
            new EntityMappedType { Key = "BL", Value = "Blog"},
            new EntityMappedType { Key = "TK", Value = "Thiết kế"},
            new EntityMappedType { Key = "RM", Value = "Phòng"},
            new EntityMappedType { Key = "FT", Value = "Dịch vụ"},
            new EntityMappedType { Key = "BST", Value = "Bộ sưu tập"}
        };

        public static List<EntityMappedType> GetTypeValueByUnitKey (string key, string unit)
        {
            if (string.IsNullOrEmpty(unit) && string.IsNullOrEmpty(key))
                return PostTypes;
            else if(string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(unit))
                return PostTypes.Where(x => x.Unit.Equals(unit)).ToList();
            else if (string.IsNullOrEmpty(unit) && !string.IsNullOrEmpty(key))
                return PostTypes.Where(x => x.Key.Equals(key)).ToList();
            else 
                return PostTypes.Where(x => x.Key.Equals(unit) && x.Unit.Equals(key)).ToList();
        }

        public static List<EntityMappedType> GetMenuTypeValueByUnitKey (string key)
        {
            if(string.IsNullOrEmpty(key))
                return MenuTypes;
            else 
                return MenuTypes.Where(x => x.Unit.Equals(key)).ToList();
        }
    }

    public class EntityMappedType
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
        public string Unit { get; set; }

    }
}
