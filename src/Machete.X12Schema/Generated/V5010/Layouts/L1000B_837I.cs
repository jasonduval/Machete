﻿namespace Machete.X12Schema.V5010.Layouts
{
    using X12;


    public interface L1000B_837I :
        X12Layout
    {
        Segment<NM1> Name { get; }
    }
}