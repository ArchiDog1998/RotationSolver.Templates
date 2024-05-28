namespace RotationSolver.ItemTemplates;

// Link to the Ratation source code
[SourceCode(Path = "%Branch/FilePath to your sourse code% eg. main/DefaultRotations/Melee/NIN_Default.cs%")]
// The detailed or extended description links of this Ratation, such as loop diagrams, recipe urls, teaching videos, etc.,
// can be written more than one
[LinkDescription("%Link to the pics or just a link%", "%Description about your rotation.%")]
[YoutubeLink(ID = "%If you got a youtube video link, please add here, just video id!%")]

//For the case your rotation is still beta.
[BetaRotation]

// Change this base class to your job's base class. It is named like XXXRotation.
[Rotation("$safeitemname$", CombatType.PvE, Description = "Your description about this rotation.", GameVersion = "6.58")]
public class Full_Template : AstrologianRotation
{
    //An example for the config. You can make it as float/int/bool/enum/Vector2/Vector2Int/Vector4/string
    [UI("The example config")]
    [Range(0, 1,  ConfigUnitType.Seconds)] //For the type float/int/Vector2/Vector2Int, you can set the range for this config.
    [RotationConfig(CombatType.PvE)] // The type of this config.
    public float SomeConfig { get; set; } // You can use it anywhere!

    #region If you want to change the auto healing, please change these bools.
    public override bool CanHealAreaSpell => base.CanHealAreaSpell;
    public override bool CanHealAreaAbility => base.CanHealAreaAbility;
    public override bool CanHealSingleSpell => base.CanHealSingleSpell;
    public override bool CanHealSingleAbility => base.CanHealSingleAbility;
    #endregion

    #region GCD actions
    protected override bool GeneralGCD(out IAction act)
    {
        throw new NotImplementedException();
    }

    //For some gcds very important, even more than healing, defense, interrupt, etc.
    protected override bool EmergencyGCD(out IAction act)
    {
        return base.EmergencyGCD(out act);
    }

    //For some gcds that moving forward.
    protected override bool MoveForwardGCD(out IAction act)
    {
        return base.MoveForwardGCD(out act);
    }

    protected override bool DefenseAreaGCD(out IAction act)
    {
        return base.DefenseAreaGCD(out act);
    }

    protected override bool DefenseSingleGCD(out IAction act)
    {
        return base.DefenseSingleGCD(out act);
    }

    protected override bool HealAreaGCD(out IAction act)
    {
        return base.HealAreaGCD(out act);
    }

    protected override bool HealSingleGCD(out IAction act)
    {
        return base.HealSingleGCD(out act);
    }

    protected override bool DispelGCD(out IAction act)
    {
        return base.DispelGCD(out act);
    }

    protected override bool RaiseGCD(out IAction act)
    {
        return base.RaiseGCD(out act);
    }
    #endregion

    #region 0GCD actions
    //Some 0gcds that don't need to a hostile target in attack range.
    protected override bool GeneralAbility(out IAction act)
    {
        return base.GeneralAbility(out act);
    }

    protected override bool AttackAbility(out IAction act)
    {
        return base.AttackAbility(out act);
    }

    //For some 0gcds very important, even more than healing, defense, interrupt, etc.
    protected override bool EmergencyAbility(IAction nextGCD, out IAction act)
    {
        return base.EmergencyAbility(nextGCD, out act);
    }

    //Some 0gcds that moving forward. In general, it doesn't need to be override.
    protected override bool MoveForwardAbility(out IAction act)
    {
        return base.MoveForwardAbility(out act);
    }

    //Some 0gcds that moving back. In general, it doesn't need to be override.
    protected override bool MoveBackAbility(out IAction act)
    {
        return base.MoveBackAbility(out act);
    }

    //Some 0gcds that speed.For example sprint.
    protected override bool SpeedAbility(out IAction act)
    {
        return base.SpeedAbility(out act);
    }

    //Some 0gcds that defense area.
    protected override bool DefenseAreaAbility(out IAction act)
    {
        return base.DefenseAreaAbility(out act);
    }

    //Some 0gcds that defense single.
    protected override bool DefenseSingleAbility(out IAction act)
    {
        return base.DefenseSingleAbility(out act);
    }

    //Some 0gcds that healing area.
    protected override bool HealAreaAbility(out IAction act)
    {
        return base.HealAreaAbility(out act);
    }

    //Some 0gcds that healing single.
    protected override bool HealSingleAbility(out IAction act)
    {
        return base.HealSingleAbility(out act);
    }

    //Some 0gcds that anti knockback.
    protected override bool AntiKnockbackAbility(out IAction act)
    {
        return base.AntiKnockbackAbility(out act);
    }

    protected override bool InterruptAbility(out IAction act)
    {
        return base.InterruptAbility(out act);
    }

    protected override bool ProvokeAbility(out IAction act)
    {
        return base.ProvokeAbility(out act);
    }

    #endregion

    #region Extra
    // Modify the type of Medicine, default is the most appropriate Medicine, generally do not need to modify
    public override MedicineType MedicineType => base.MedicineType;

    //For counting down action when pary counting down is active.
    protected override IAction CountDownAction(float remainTime)
    {
        return base.CountDownAction(remainTime);
    }


    //This is the method to update all field you wrote, it is used first during one frame.
    protected override void UpdateInfo()
    {
        base.UpdateInfo();
    }

    //This method is used when player change the terriroty, such as go into one duty, you can use it to set the field.
    public override void OnTerritoryChanged()
    {
        base.OnTerritoryChanged();
    }

    //This method is used to debug. If you want to show some information in Debug panel, show something here.
    public override void DisplayStatus()
    {
        base.DisplayStatus();
    }

    // Modify this bool to display your DisplayStatus on the Formal Page.
    public override bool ShowStatus => base.ShowStatus;
    #endregion
}
