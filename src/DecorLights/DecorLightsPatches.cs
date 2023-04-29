using HarmonyLib;
using CaiLib.Utils;
using static CaiLib.Utils.BuildingUtils;
using static CaiLib.Utils.StringUtils;

namespace DecorLights
{
	public class DecorLightsPatches
	{
		[HarmonyPatch(typeof(GeneratedBuildings))]
		[HarmonyPatch(nameof(GeneratedBuildings.LoadGeneratedBuildings))]
		public static class GeneratedBuildings_LoadGeneratedBuildings_Patch
		{
			public static void Prefix()
			{
				AddBuildingStrings(LavaLampConfig.Id, LavaLampConfig.DisplayName, LavaLampConfig.Description, LavaLampConfig.Effect);
				AddBuildingStrings(CeilingLampConfig.Id, CeilingLampConfig.DisplayName, CeilingLampConfig.Description, CeilingLampConfig.Effect);

				AddBuildingToPlanScreen(GameStrings.PlanMenuCategory.Furniture, LavaLampConfig.Id);
				AddBuildingToPlanScreen(GameStrings.PlanMenuCategory.Furniture, CeilingLampConfig.Id);
			}
		}

		[HarmonyPatch(typeof(Db))]
		[HarmonyPatch("Initialize")]
		public static class Db_Initialize_Patch
		{
			public static void Postfix()
			{
				AddBuildingToTechnology(GameStrings.Technology.Decor.GlassBlowing, LavaLampConfig.Id);
				AddBuildingToTechnology(GameStrings.Technology.Decor.GlassBlowing, CeilingLampConfig.Id);
			}
		}
	}
}
