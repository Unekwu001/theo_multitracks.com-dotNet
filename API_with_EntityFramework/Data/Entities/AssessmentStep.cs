using System;
using System.Collections.Generic;

namespace API_with_EntityFramework.Data.Entities;

public partial class AssessmentStep
{
    public int StepId { get; set; }

    public string Text { get; set; } = null!;
}
