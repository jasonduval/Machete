// This file was automatically generated and may be regenerated at any
// time. To ensure any changes are retained, modify the tool with any segment/component/group/field name
// or type changes.
namespace Machete.HL7Schema.V26.Maps
{
    using V26;

    /// <summary>
    /// RSP_Z82_VISIT (GroupMap) - 
    /// </summary>
    public class RSP_Z82_VISITMap :
        HL7V26LayoutMap<RSP_Z82_VISIT>
    {
        public RSP_Z82_VISITMap()
        {
            Segment(x => x.AL1, 0, x => x.Required = true);
            Segment(x => x.PV1, 1, x => x.Required = true);
            Segment(x => x.PV2, 2);
        }
    }
}