using Enums;

namespace SwitchGiftDataManager.Core;

public class OtherGift
{
    public object? Type { get; set; }
    public ushort Item { get; set; }
    public uint Quantity { get; set; }
    public ushort Opt { get; set; }

    public string GetItemName() => GetItemName(Item, Type!, Opt);

    public static string GetItemName(ushort id, object type, ushort opt = 0)
    {
        var str = "";

        if (type.GetType() == typeof(GiftType7))
        {
            if ((GiftType7)type is GiftType7.Item)
                str = Properties.Resources.Items.Split(new String[] { "\n" }, StringSplitOptions.None)[id];
            else
                str = ((GiftType7)type).ToString();
        }
        else if (type.GetType() == typeof(GiftType8))
        {
            if ((GiftType8)type is GiftType8.Item)
                str = Properties.Resources.Items.Split(new String[] { "\n" }, StringSplitOptions.None)[id];
            else if ((GiftType8)type is GiftType8.Clothing)
                {
                    var category = (ClothingType8)id;
                    var description = category switch
                    {
                        ClothingType8.Glasses => Properties.Resources.SWSHClothingGlasses.Split(new String[] { "\n" }, StringSplitOptions.None)[opt],
                        ClothingType8.Hats => Properties.Resources.SWSHClothingHats.Split(new String[] { "\n" }, StringSplitOptions.None)[opt],
                        ClothingType8.Jackets => Properties.Resources.SWSHClothingJackets.Split(new String[] { "\n" }, StringSplitOptions.None)[opt],
                        ClothingType8.Tops => Properties.Resources.SWSHClothingTops.Split(new String[] { "\n" }, StringSplitOptions.None)[opt],
                        ClothingType8.Bags => Properties.Resources.SWSHClothingBags.Split(new String[] { "\n" }, StringSplitOptions.None)[opt],
                        ClothingType8.Gloves => Properties.Resources.SWSHClothingGloves.Split(new String[] { "\n" }, StringSplitOptions.None)[opt],
                        ClothingType8.Bottoms => Properties.Resources.SWSHClothingBottoms.Split(new String[] { "\n" }, StringSplitOptions.None)[opt],
                        ClothingType8.Legwear => Properties.Resources.SWSHClothingLegwear.Split(new String[] { "\n" }, StringSplitOptions.None)[opt],
                        ClothingType8.Footwear => Properties.Resources.SWSHClothingShoes.Split(new String[] { "\n" }, StringSplitOptions.None)[opt],
                        _ => throw new ArgumentOutOfRangeException(),
                    };
                    str = $"[{category}] {description}";
                }
            else
                str = ((GiftType8)type).ToString();
        }
        else if(type.GetType() == typeof(GiftType8B))
        {
            if ((GiftType8B)type is GiftType8B.Item)
                str = Properties.Resources.Items.Split(new String[] { "\n" }, StringSplitOptions.None)[id];
            else if ((GiftType8B)type is GiftType8B.Clothing)
                str = Properties.Resources.BDSPClothing.Split(new String[] { "\n" }, StringSplitOptions.None)[id];
            else if ((GiftType8B)type is GiftType8B.Underground)
                str = Properties.Resources.UndergroundItems.Split(new String[] { "\n" }, StringSplitOptions.None)[id];
            else
                str = ((GiftType8B)type).ToString();
        }
        else if (type.GetType() == typeof(GiftType8A))
        {
            if ((GiftType8A)type is GiftType8A.Item)
                str = Properties.Resources.Items.Split(new String[] { "\n" }, StringSplitOptions.None)[id];
            else if ((GiftType8A)type is GiftType8A.Clothing)
            {
                var category = (ClothingType8A)id;
                var description = category switch
                {
                    ClothingType8A.Headwear => Properties.Resources.PLAClothingHeads.Split(new String[] { "\n" }, StringSplitOptions.None)[opt],
                    ClothingType8A.Tops => Properties.Resources.PLAClothingTops.Split(new String[] { "\n" }, StringSplitOptions.None)[opt],
                    ClothingType8A.Bottoms => Properties.Resources.PLAClothingBottoms.Split(new String[] { "\n" }, StringSplitOptions.None)[opt],
                    ClothingType8A.Outfit => "",
                    ClothingType8A.Footwear => "",
                    ClothingType8A.Glasses => "",
                    ClothingType8A.Eyewear => "",
                    _ => throw new ArgumentOutOfRangeException(),
                };
                if(string.IsNullOrWhiteSpace(description))
                    description = $"{opt:X4}";
                str = $"[{category}] {description}";
            }
            else
                str = ((GiftType8A)type).ToString();
        }
        else if (type.GetType() == typeof(GiftType9))
        {
            if ((GiftType9)type is GiftType9.Item)
                str = Properties.Resources.Items.Split(new String[] { "\n" }, StringSplitOptions.None)[id];
            else if ((GiftType9)type is GiftType9.Clothing)
            {
                var category = (ClothingType9)id;
                var description = Properties.Resources.SCVIClothings.Split(new String[] { "\n" }, StringSplitOptions.None)[opt];
                if (string.IsNullOrWhiteSpace(description))
                    description = $"{opt:X4}";
                str = $"[{category.ToString().Replace("Uniform", "Clothing")}] {description}";
            }
            else
                str = ((GiftType9)type).ToString();
        }

        return str;
    }
}