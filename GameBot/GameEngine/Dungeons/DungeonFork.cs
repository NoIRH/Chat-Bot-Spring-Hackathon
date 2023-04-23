using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Dungeons
{
    public class DungeonFork
    {
        public int Id { get; set; }
        private List<DangeonVariantStep> _variants;
        public List<DangeonVariantStep> GetVariants()
        {
            _variants = new List<DangeonVariantStep>();
            var enumCount = Enum.GetNames(typeof(DangeonVariantStep)).Length;
            Random r = new Random();   
            for (int i = 0; i < enumCount; i++)
            {
                _variants.Add(new DangeonVariantStep());
                _variants[i] = (DangeonVariantStep) r.Next(0,enumCount);
            }
            return _variants;
        }
    }
}
