using MagicVilla.Dtos;

namespace MagicVilla.Data
{
    public static class VillaStore
    {
        public static List<VillaDto> villaList = new () {
            new VillaDto{ID=1,Name = "Villa 1"},
            new VillaDto{ID=2,Name = "Villa 2"},
            new VillaDto{ID=3,Name = "Villa 3"},
            new VillaDto{ID=4,Name = "Villa 4"},
            };
    }
}
