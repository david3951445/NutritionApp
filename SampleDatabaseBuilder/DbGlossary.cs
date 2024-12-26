namespace SampleDatabaseBuilder.Services;

public static class DbGlossary
{
    public static ItemCatagory ItemCatagory { get; } = new();
    public static GeneralIngredients GeneralIngredients { get; } = new();
    public static SugarAnalysis SugarAnalysis { get; } = new();
    public static AminoAcidComposition AminoAcidComposition { get; } = new();
    public static FattyAcidComposition FattyAcidComposition { get; } = new();
    public static VitaminA VitaminA { get; } = new();
    public static VitaminBC VitaminBC { get; } = new();
    public static VitaminD VitaminD { get; } = new();
    public static VitaminE VitaminE { get; } = new();
    public static VitaminK VitaminK { get; } = new();
    public static Minerals Minerals { get; } = new();
    public static Others Others { get; } = new();
}

public interface IOrderedGlossary
{
    string[] OrderedNames { get; }
}

public class ItemCatagory : IOrderedGlossary
{
    public const string GeneralIngredients = "一般成分";
    public const string SugarAnalysis = "糖質分析";
    public const string AminoAcidComposition = "胺基酸組成";
    public const string FattyAcidComposition = "脂肪酸組成";
    public const string VitaminA = "維生素A";
    public const string VitaminBC = "維生素B群 & C";
    public const string VitaminD = "維生素D";
    public const string VitaminE = "維生素E";
    public const string VitaminK = "維生素K";
    public const string Minerals = "礦物質";
    public const string Others = "其他";

    private readonly string[] _orderedNames =
    [
        GeneralIngredients,
        SugarAnalysis,
        AminoAcidComposition,
        FattyAcidComposition,
        VitaminA,
        VitaminBC,
        VitaminD,
        VitaminE,
        VitaminK,
        Minerals,
        Others,
    ];
    public string[] OrderedNames => _orderedNames;

    public string[] GetSubItems(string catagory) => catagory switch
    {
        GeneralIngredients => DbGlossary.GeneralIngredients.OrderedNames,
        SugarAnalysis => DbGlossary.SugarAnalysis.OrderedNames,
        AminoAcidComposition => DbGlossary.AminoAcidComposition.OrderedNames,
        FattyAcidComposition => DbGlossary.FattyAcidComposition.OrderedNames,
        VitaminA => DbGlossary.VitaminA.OrderedNames,
        VitaminBC => DbGlossary.VitaminBC.OrderedNames,
        VitaminD => DbGlossary.VitaminD.OrderedNames,
        VitaminE => DbGlossary.VitaminE.OrderedNames,
        VitaminK => DbGlossary.VitaminK.OrderedNames,
        Minerals => DbGlossary.Minerals.OrderedNames,
        Others => DbGlossary.Others.OrderedNames,
        _ => []
    };
};

public class GeneralIngredients : IOrderedGlossary
{
    public const string Calorie = "熱量";
    public const string ModifiedCalorie = "修正熱量";
    public const string Moisture = "水分";
    public const string TotalCarbohydrate = "總碳水化合物";
    public const string DietaryFiber = "膳食纖維";
    public const string CrudeProtein = "粗蛋白";
    public const string CrudeFat = "粗脂肪";
    public const string SaturatedFat = "飽和脂肪";
    public const string Ash = "灰分";

    private readonly string[] _orderedNames =
    [
        Calorie,
        ModifiedCalorie,
        Moisture,
        TotalCarbohydrate,
        DietaryFiber,
        CrudeProtein,
        CrudeFat,
        SaturatedFat,
        Ash,
    ];
    public string[] OrderedNames => _orderedNames;
}

public class SugarAnalysis : IOrderedGlossary
{
    public const string Galactose = "半乳糖";
    public const string Lactose = "乳糖";
    public const string Fructose = "果糖";
    public const string Maltose = "麥芽糖";
    public const string Glucose = "葡萄糖";
    public const string Sucrose = "蔗糖";
    public const string TotalSugar = "糖質總量";

    private readonly string[] _orderedNames =
    [
        TotalSugar,
        Lactose,
        Maltose,
        Sucrose,
        Fructose,
        Galactose,
        Glucose,
    ];
    public string[] OrderedNames => _orderedNames;
}

public class AminoAcidComposition : IOrderedGlossary
{
    public const string Asp = "天門冬胺酸(Asp)";
    public const string TotalAminoAcid = "水解胺基酸總量";
    public const string Ala = "丙胺酸(Ala)";
    public const string Gly = "甘胺酸(Gly)";
    public const string Met = "甲硫胺酸(Met)";
    public const string Leu = "白胺酸(Leu)";
    public const string Trp = "色胺酸(Trp)";
    public const string Phe = "苯丙胺酸(Phe)";
    public const string Cys = "胱胺酸(Cys)";
    public const string Ile = "異白胺酸(Ile)";
    public const string His = "組胺酸(His)";
    public const string Pro = "脯胺酸(Pro)";
    public const string Ser = "絲胺酸(Ser)";
    public const string Thr = "酥胺酸(Thr)";
    public const string Tyr = "酪胺酸(Tyr)";
    public const string Arg = "精胺酸(Arg)";
    public const string Glu = "麩胺酸(Glu)";
    public const string Lys = "離胺酸(Lys)";
    public const string Val = "纈胺酸(Val)";

    private readonly string[] _orderedNames =
    [
        TotalAminoAcid,
        Asp,
        Ala,
        Gly,
        Met,
        Leu,
        Trp,
        Phe,
        Cys,
        Ile,
        His,
        Pro,
        Ser,
        Thr,
        Tyr,
        Arg,
        Glu,
        Lys,
        Val,
    ];
    public string[] OrderedNames => _orderedNames;
}

public class FattyAcidComposition : IOrderedGlossary
{
    public const string CetoleicAcid = "鱈烯酸(20:1)";
    public const string PMS = "P/M/S";
    public const string MargaricAcid = "十七酸(17:0)";
    public const string NonadecylicAcid = "十九酸(19:0)";
    public const string StearidonicAcid = "十八碳四烯酸(18:4)";
    public const string TridecylicAcid = "十三酸(13:0)";
    public const string PentadecylicAcid = "十五酸(15:0)";
    public const string BehenicAcid = "山酸(22:0)";
    public const string CaproicAcid = "己酸(6:0)";
    public const string DocosapentaenoicAcid = "廿二碳五烯酸(22:5)";
    public const string DocosahexaenoicAcid = "廿二碳六烯酸(22:6)";
    public const string LignocericAcid = "廿四酸(24:0)";
    public const string EicosapentaenoicAcid = "廿碳五烯酸(20:5)";
    public const string LauricAcid = "月桂酸(12:0)";
    public const string AlphaLinolenicAcid = "次亞麻油酸(18:3)";
    public const string MyristoleicAcid = "肉豆蔻烯酸(14:1)";
    public const string MyristicAcid = "肉豆蔻酸(14:0)";
    public const string CaprylicAcid = "辛酸(8:0)";
    public const string LinoleicAcid = "亞麻油酸(18:2)";
    public const string OtherFattyAcids = "其他脂肪酸";
    public const string OleicAcid = "油酸(18:1)";
    public const string ArachidonicAcid = "花生油酸(20:4)";
    public const string ArachidicAcid = "花生酸(20:0)";
    public const string ErucicAcid = "芥子酸(22:1)";
    public const string CapricAcid = "癸酸(10:0)";
    public const string TotalMonounsaturatedFattyAcids = "脂肪酸M總量";
    public const string TotalPolyunsaturatedFattyAcids = "脂肪酸P總量";
    public const string TotalSaturatedFattyAcids = "脂肪酸S總量";
    public const string PalmitoleicAcid = "棕櫚烯酸(16:1)";
    public const string PalmiticAcid = "棕櫚酸(16:0)";
    public const string StearicAcid = "硬脂酸(18:0)";
    public const string ButyricAcid = "酪酸(4:0)";

    private readonly string[] _orderedNames =
    [
        TotalMonounsaturatedFattyAcids,
        TotalPolyunsaturatedFattyAcids,
        TotalSaturatedFattyAcids,
        PMS,
        DocosahexaenoicAcid, // P
        DocosapentaenoicAcid, // P
        EicosapentaenoicAcid, // P
        StearidonicAcid, // P
        AlphaLinolenicAcid, // P
        LinoleicAcid, // P
        ArachidonicAcid, // P
        ErucicAcid, // M
        OleicAcid, // M
        PalmitoleicAcid, // M
        MyristoleicAcid, // M
        CetoleicAcid, // M
        MargaricAcid, // S
        NonadecylicAcid, // S
        LignocericAcid, // S
        StearicAcid, // S
        ArachidicAcid, // S
        BehenicAcid, // S
        CaproicAcid, // S
        CapricAcid, // S
        CaprylicAcid, // S
        LauricAcid, // S
        MyristicAcid, // S
        PalmiticAcid, // S
        PentadecylicAcid, // S
        TridecylicAcid, // S
        ButyricAcid, // S
        OtherFattyAcids,
    ];
    public string[] OrderedNames => _orderedNames;
}

public class VitaminA : IOrderedGlossary
{
    public const string AlphaCarotene = "α-胡蘿蔔素";
    public const string BetaCarotene = "β-胡蘿蔔素";
    public const string Retinol = "視網醇";
    public const string RetinolEquivalent = "視網醇當量(RE)";
    public const string TotalVitaminA = "維生素A總量(IU)";

    private readonly string[] _orderedNames =
    [
        TotalVitaminA,
        AlphaCarotene,
        BetaCarotene,
        Retinol,
        RetinolEquivalent,
    ];
    public string[] OrderedNames => _orderedNames;
}

public class VitaminBC : IOrderedGlossary
{
    public const string VitaminB1 = "維生素B1";
    public const string VitaminB2 = "維生素B2";
    public const string Niacin = "菸鹼素";
    public const string VitaminB6 = "維生素B6";
    public const string Biotin = "生物素";
    public const string FolicAcid = "葉酸";
    public const string VitaminB12 = "維生素B12";
    public const string VitaminC = "維生素C";

    private readonly string[] _orderedNames =
    [
        VitaminB1,
        VitaminB2,
        Niacin,
        VitaminB6,
        Biotin,
        VitaminB12,
        FolicAcid,
        VitaminC,
    ];
    public string[] OrderedNames => _orderedNames;
}

public class VitaminD : IOrderedGlossary
{
    public const string VitaminD2 = "維生素D2";
    public const string VitaminD3 = "維生素D3";
    public const string TotalVitaminD_IU = "維生素D總量(IU)";
    public const string TotalVitaminD_ug = "維生素D總量(ug)";

    private readonly string[] _orderedNames =
    [
        TotalVitaminD_IU,
        TotalVitaminD_ug,
        VitaminD2,
        VitaminD3,
    ];
    public string[] OrderedNames => _orderedNames;
}

public class VitaminE : IOrderedGlossary
{
    public const string AlphaTocopherol = "α-生育酚";
    public const string AlphaTocopherolEquivalent = "α-維生素E當量(α-TE)";
    public const string BetaTocopherol = "β-生育酚";
    public const string GammaTocopherol = "γ-生育酚";
    public const string DeltaTocopherol = "δ-生育酚";
    public const string TotalVitaminE = "維生素E總量";

    private readonly string[] _orderedNames =
    [
        TotalVitaminE,
        AlphaTocopherolEquivalent,
        AlphaTocopherol,
        BetaTocopherol,
        GammaTocopherol,
        DeltaTocopherol,
    ];
    public string[] OrderedNames => _orderedNames;
}

public class VitaminK : IOrderedGlossary
{
    public const string VitaminK1 = "維生素K1";
    public const string VitaminK2_MK4 = "維生素K2(MK-4)";
    public const string VitaminK2_MK7 = "維生素K2(MK-7)";

    private readonly string[] _orderedNames =
    [
        VitaminK1,
        VitaminK2_MK4,
        VitaminK2_MK7,
    ];
    public string[] OrderedNames => _orderedNames;
}

public class Minerals : IOrderedGlossary
{
    public const string Calcium = "鈣";
    public const string Sodium = "鈉";
    public const string Potassium = "鉀";
    public const string Copper = "銅";
    public const string Zinc = "鋅";
    public const string Manganese = "錳";
    public const string Phosphorus = "磷";
    public const string Magnesium = "鎂";
    public const string Iron = "鐵";

    private readonly string[] _orderedNames =
    [
        Calcium,
        Sodium,
        Potassium,
        Copper,
        Zinc,
        Manganese,
        Phosphorus,
        Magnesium,
        Iron,
    ];
    public string[] OrderedNames => _orderedNames;
}

public class Others : IOrderedGlossary
{
    public const string TransFat = "反式脂肪";
    public const string AlcoholContent = "酒精含量";
    public const string Cholesterol = "膽固醇";

    private readonly string[] _orderedNames =
    [
        TransFat,
        AlcoholContent,
        Cholesterol,
    ];
    public string[] OrderedNames => _orderedNames;
}
