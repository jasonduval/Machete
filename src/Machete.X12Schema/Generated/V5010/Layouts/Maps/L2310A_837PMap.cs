﻿namespace Machete.X12Schema.V5010.Maps
{
    using X12;
    using X12.Configuration;


    public class L2310A_837PMap :
        X12LayoutMap<L2310A_837P, X12Entity>
    {
        public L2310A_837PMap()
        {
            Id = "2310A";
            Name = "Referring Provider Name";
            
            Segment(x => x.ReferringProvider, 0);
            Segment(x => x.SecondaryIdentification, 1);
        }
    }
}