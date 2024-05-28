using RotationSolver.Basic.Record;

namespace RotationSolver.ItemTemplates;

[DutyTerritory(1166u)] //Set the territory id of this duty!
[Rotation("$safeitemname$", CombatType.PvE, Description = "Your description about this rotation.", GameVersion = "6.58")]
public class Duty_Template : DutyRotation //Maybe there are some rotations with the DutyTerritory
{
    //You can use the GetRecordData to get better control of the rotations.
    #region Similar to job rotation.
    public override bool EmergencyGCD(out IAction act)
    {
        return base.EmergencyGCD(out act);
    }

    public override bool EmergencyAbility(IAction nextGCD, out IAction act)
    {
        return base.EmergencyAbility(nextGCD, out act);
    }
    #endregion

    #region Triggers. For adding ActorVfx or StaticVfx or control the rotations.
    public override void OnActorVfxNew(in VfxNewData data)
    {
        base.OnActorVfxNew(data);
    }

    public override void OnMapEffect(in MapEffectData data)
    {
        base.OnMapEffect(data);
    }

    public override void OnNewActor(in ObjectNewData data)
    {
        base.OnNewActor(data);
    }

    public override void OnObjectEffect(in ObjectEffectData data)
    {
        base.OnObjectEffect(data);
    }

    public override void OnActionFromEnemy(in ActionEffectSetData data)
    {
        base.OnActionFromEnemy(data);
    }
    #endregion

    #region Drawing
    public override void UpdateDrawing()
    {
        base.UpdateDrawing();
    }

    public override void DestroyAllDrawing()
    {
        base.DestroyAllDrawing();
    }
    #endregion
}
