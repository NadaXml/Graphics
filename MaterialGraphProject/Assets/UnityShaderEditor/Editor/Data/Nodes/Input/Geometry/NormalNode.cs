using UnityEngine;
using UnityEditor.Graphing;

namespace UnityEditor.ShaderGraph
{
    [Title("Input/Geometry/Normal")]
    public class NormalNode : GeometryNode, IMayRequireNormal
    {
        public const int kOutputSlotId = 0;
        public const string kOutputSlotName = "Out";

        public NormalNode()
        {
            name = "Normal";
            UpdateNodeAfterDeserialization();
        }

        public sealed override void UpdateNodeAfterDeserialization()
        {
            AddSlot(new Vector3MaterialSlot(kOutputSlotId, kOutputSlotName, kOutputSlotName, SlotType.Output, new Vector4(0, 0, 1)));
            RemoveSlotsNameNotMatching(new[] { kOutputSlotId });
        }

        public override string GetVariableNameForSlot(int slotId)
        {
            return space.ToVariableName(InterpolatorType.Normal);
        }

        public NeededCoordinateSpace RequiresNormal()
        {
            return space.ToNeededCoordinateSpace();
        }
    }
}
