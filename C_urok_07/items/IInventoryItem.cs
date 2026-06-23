using CSharpStudy.C_urok_07.structs;

namespace CSharpStudy.C_urok_07.items {
    internal interface IInventoryItem {
        string Name { get; }
        decimal Price { get; }
        int Quantity { get; set; }
        CategoryInfo Category { get; }
        string Info { get; }
    }
}
