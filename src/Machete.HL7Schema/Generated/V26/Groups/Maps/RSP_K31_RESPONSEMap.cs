// This file was automatically generated and may be regenerated at any
// time. To ensure any changes are retained, modify the tool with any segment/component/group/field name
// or type changes.
namespace Machete.HL7Schema.V26.Maps
{
    using V26;

    /// <summary>
    /// RSP_K31_RESPONSE (GroupMap) - 
    /// </summary>
    public class RSP_K31_RESPONSEMap :
        HL7V26LayoutMap<RSP_K31_RESPONSE>
    {
        public RSP_K31_RESPONSEMap()
        {
            Layout(x => x.Patient, 0);
            Layout(x => x.Order, 1, x => x.Required = true);
        }
    }
}