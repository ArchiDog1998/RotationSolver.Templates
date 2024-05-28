namespace RotationSolver.ItemTemplates;

// Change this base class to your job's base class. It is named like XXXRotation.
[Rotation("$safeitemname$", CombatType.PvE, Description = "Your description about this rotation.", GameVersion = "6.58")]
public class Simple_Template : AstrologianRotation
{
    //GCD actions here.
    protected override bool GeneralGCD(out IAction act)
    {
        throw new NotImplementedException();
    }

    //0GCD actions here.
    protected override bool AttackAbility(out IAction act)
    {
        return base.AttackAbility(out act);
    }
}
