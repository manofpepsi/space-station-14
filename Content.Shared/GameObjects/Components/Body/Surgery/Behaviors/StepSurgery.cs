﻿#nullable enable
using Content.Shared.GameObjects.Components.Body.Part;
using Content.Shared.GameObjects.Components.Body.Surgery.Step;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization.Manager.Attributes;

namespace Content.Shared.GameObjects.Components.Body.Surgery.Behaviors
{
    public class StepSurgery : SurgeryBehavior
    {
        [field: DataField("step")] private string? StepId { get; set; }

        public SurgeryStepPrototype? Step => StepId == null
            ? null
            : IoCManager.Resolve<IPrototypeManager>().Index<SurgeryStepPrototype>(StepId);

        public override bool Perform(IEntity performer, IBodyPart part)
        {
            if (Step == null)
            {
                return false;
            }

            return part.AddSurgeryTag(Step.ID);
        }
    }
}
