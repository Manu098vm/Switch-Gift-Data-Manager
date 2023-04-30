namespace Enums {
    public enum Games : int
    {
        None = 0,
        LGPE = 1,
        SWSH = 2,
        BDSP = 3,
        PLA = 4,
        SCVI = 5,
    }

    public enum WCType
    {
        Pokemon,
        Item,
    }

    internal enum WondercardSize : ushort
    {
        WB7 = 0x310,
        WC8 = 0x2D0,
        WB8 = 0x2DC,
        WA8 = 0x2C8,
        WC9 = 0x2C8,
    }

    internal enum GiftType7 : byte
    {
        Pokemon = 0,
        Item = 1,
        Bean = 2,
        BP = 3,
    }

    internal enum GiftType8 : byte
    {
        None = 0,
        Pokemon = 1,
        Item = 2,
        BP = 3,
        Clothing = 4,
        Money = 5,
    }

    internal enum GiftType8B : byte
    {
        None = 0,
        Pokemon = 1,
        Item = 2,
        BP = 3,
        Clothing = 4,
        Money = 5,
        Underground = 6,
    }

    internal enum GiftType8A : byte
    {
        None = 0,
        Pokemon = 1,
        Item = 2,
        Clothing = 3,
    }

    internal enum GiftType9 : byte
    {
        None = 0,
        Pokemon = 1,
        Item = 2,
        LP = 3,
        Clothing = 4,
    }

    public enum PIDType
    {
        RandomPID,
        FixedPID,
    }

    public enum ShinyType
    {
        ShinyLocked,
        ShinyPossible,
        ShinyForced,
        ShinyTIDAbuse,
        ShinyHighOdds,
    }

    internal enum ShinyType7 : byte
    {
        Fixed = 0,
        ShinyRandom = 1,
        Shiny = 2,
        ShinyLocked = 3,
    }

    internal enum ShinyType8 : byte
    {
        ShinyLocked = 0,
        ShinyRandom = 1,
        ShinyStar = 2,
        ShinySquare = 3,
        Fixed = 4,
    }

    internal enum ShinyType9 : byte
    {
        ShinyLocked = 0,
        ShinyRandom = 1,
        ShinyStar = 2,
        ShinySquare = 3,
        Fixed = 4,
    }

    internal enum ClothingType8: byte
    {
        Glasses = 0x06,
        Hats = 0x07,
        Jackets = 0x08,
        Tops = 0x09,
        Bags = 0x0A,
        Gloves = 0x0B,
        Bottoms = 0x0C,
        Legwear = 0x0D,
        Footwear = 0x0E,
        None = 0xFF,
    }

    internal enum ClothingType8A: byte
    {
        Headwear = 0x00,
        Tops = 0x01,
        Bottoms = 0x02,
        Outfit = 0x03,
        Footwear = 0x5,
        Glasses = 0x06,
        Eyewear = 0x08,
        None = 0xFF,
    }

    internal enum ClothingType9 : byte
    {
        Uniform = 0x00,
        Legwear = 0x01,
        Footwear = 0x02,
        Gloves = 0x03,
        Bags = 0x04,
        Headwear = 0x5,
        Eyewear = 0x06,
        PhoneCase = 0x08,
        None = 0xFF,
    }
}