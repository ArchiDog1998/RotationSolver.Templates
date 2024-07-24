# CanUse

It is a complex method that used everywhere. In a word, it will check a lot of things.

Level, Enabled, Action Status, MP, Player Status, Coll down, Combo, Moving (for casting), Charges, Target, etc.

Check the source code [here](https://github.com/ArchiDog1998/RotationSolver/blob/dae05a0777ed567ac4f7512244887fe7e7cc9f2a/RotationSolver/Actions/BaseAction/BaseAction_ActionInfo.cs#L54).

## Usage

High-damage actions always have multiple restrictions.  Use them at first, then AOEs, then single targets. DOT actions always have some target status, so use it above.

## Param

some param you can use here.

### mustUse

AOE action will be used on a single target.

Moving actions will skip checking for distance. 

Skip for StatusProvide and TargetStatus checking.

### emptyOrSkipCombo

Use up all charges, without keeping one.

Do not need to check the combo.

### skipDisable

Skip the disable for emergency use. Please always set this to false.

# Rotation Part

We just started a simple 123 rotation. Obviously, it doesn't solve the complex combats. In this part, lets see how many methods can we override, and how to use them. That is the major work for the rotation developers.

## GCD

General Cooldown Actions, which contains Weapon Skill and Spell.

But in Rotation Solver, not only actions above can add into these methods. It means, when GCD is cooled down, will choose one of them to use.

For example. BLM is a special job. In many case it needs to use `Triplecast` after `Fire4`. But when fire 4 is finished, GCD is cooled down. So `Triplecast`  is a case that need to be used in GCD.

The code that defines these methods is [here](https://github.com/ArchiDog1998/RotationSolver/blob/78ede8c386e3c37708b3cb15f259ccf4b839caaf/RotationSolver/Rotations/CustomRotation/CustomRotation_GCD.cs#L79-L109).

### EmergencyGCD

This is a method with the highest priority, even higher than raise, heal and defense. So it is rarely used. I only use it on RDM. Because I don't want to use `Verraise` when I am burst with Scorch, etc.

```c#
    private protected override bool EmergencyGCD(out IAction? act)
    {
        act = null; return false;
    }
```

### MoveGCD

Only use when player input the macro with `Move Forward`.

``` c#
    private protected override bool MoveGCD(out IAction? act)
    {
        act = null; return false;
    }
```

### HealSingleGCD

When need to use spell to heal one player. 

``` c#
    private protected override bool HealSingleGCD(out IAction? act)
    {
        act = null; return false;
    }
```

### HealAreaGCD

When need to use spell to heal multiple players. 

``` c#
    private protected override bool HealAreaGCD(out IAction? act)
    {
        act = null; return false;
    }
```

### DefenseSingleGCD

When need to use spell to defense for one player.

``` c#
    private protected override bool DefenseSingleGCD(out IAction? act)
    {
        act = null; return false;
    }
```

### DefenseAreaGCD

When need to use spell to defense for multiple players.

``` c#
    private protected override bool DefenseAreaGCD(out IAction? act)
    {
        act = null; return false;
    }
```

### GeneralGCD

Just normal GCD. Always for attack.

``` c#
    private protected override bool GeneralGCD(out IAction? act)
    {
        act = null; return false;
    }
```



## Ability

If GCD is not cooled down, Rotation Solver will find an action from abilities.

`abilitiesRemaining` means how many abilities will be used before next GCD. 

The code that defines these methods is [here](https://github.com/ArchiDog1998/RotationSolver/blob/78ede8c386e3c37708b3cb15f259ccf4b839caaf/RotationSolver/Rotations/CustomRotation/CustomRotation_Ability.cs#L251-L306).

### EmergencyAbility

This is a method with the highest priority. And only this method has `nextGCD` parameter.  The logic `before` is there. You may want to use `IsTheSameTo` method to check what is the next action.

``` c#
    private protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {
        act = null; return false;
    }
```

Here is the example for MCH.

``` c#
    private protected override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {
        if (nextGCD.IsTheSameTo(true, ChainSaw))
        {
            if (Reassemble.CanUse(out act, emptyOrSkipCombo: true)) return true;
        }
        return base.EmergencyAbility(abilitiesRemaining, nextGCD, out act);
    }
```

### MoveForwardAbility

Only use when player input the macro with `Move Forward`.

``` c#
    private protected override bool MoveForwardAbility(out IAction? act)
    {
        act = null; return false;
    }
```

### MoveBackAbility

Only use when player input the macro with `Move Back`.

``` c#
    private protected override bool MoveBackAbility(out IAction? act)
    {
        act = null; return false;
    }
```

### HealSingleAbility

When need to use ability to heal one player. 

``` c#
    private protected override bool HealSingleAbility(out IAction? act)
    {
        act = null; return false;
    }
```

### HealAreaAbility

When need to use ability to heal multiple players. 

``` c#
    private protected override bool HealAreaAbility(out IAction? act)
    {
        act = null; return false;
    }
```

### DefenceSingleAbility

When need to use ability to defense for one player. 

``` c#
    private protected override bool DefenceSingleAbility(out IAction? act)
    {
        act = null; return false;
    }
```

### DefenceAreaAbility

When need to use ability to defense for multiple players. 

``` c#
    private protected override bool DefenceAreaAbility(out IAction? act)
    {
        act = null; return false;
    }
```

### GeneralAbility

Just normal abilities. No need for hostile target.

``` c#
    private protected override bool GeneralAbility(out IAction? act)
    {
        act = null; return false;
    }
```

### AttackAbility

Need for hostile target in attack range. Ranged roles are 25, others are 3.

``` c#
    private protected override bool AttackAbility(out IAction? act)
    {
        act = null; return false;
    }
```

## Specials

One more thing...

### CountDownAction

When counting down, you can actions on time.

``` c#
    private protected override IAction CountDownAction(float remainTime)
    {
        return null;
    }
```

For example of PLD.

``` c#
    private protected override IAction CountDownAction(float remainTime)
    {
        if (remainTime <= 2 && HolySpirit.CanUse(out var act)) return act;

        if (remainTime <= 15 && DivineVeil.CanUse(out act)) return act;

        return base.CountDownAction(remainTime);
    }
```

# Rotation Information

So we need to fill the blank in the methods mentioned [before](RotationDev/rotation.md). But what data do we need to organize the [logic](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/boolean-logical-operators) with? First of all, there is the information in rotation.

## Player

| Property      | Description                                                 |
| ------------- | ----------------------------------------------------------- |
| Player        | This is the player.                                         |
| Level         | The level of the player.                                    |
| HasSwift      | Does player have swift cast, dual cast or triple cast.      |
| HasTankStance | Does player have grit, royal guard,  iron will or defiance. |



## Target

| Property      | Description                    |
| ------------- | ------------------------------ |
| Target        | The player's target.           |
| IsTargetDying | Shortcut for Target.IsDying(); |
| IsTargetBoss  | Shortcut for Target.IsBoss();  |



## Status

| Property           | Description                                                  |
| ------------------ | ------------------------------------------------------------ |
| InCombat           | Is in combat.                                                |
| IsMoving           | Check the player is moving, such as running, walking or jumping. |
| HasHostilesInRange | Is there any hostile target in the range? 25 for ranged jobs and healer, 3 for melee and tank. |
| IsFullParty        | Whether the number of party members is 8.                    |
| InBurst            | Is in burst right now? Usually it used with team support actions. |



## Job Gauge

Job gauge is a little bit complex. And it depends on the certain job.

If there are some time stuffs, usually two methods are available.

| Method         | Description                                    |
| -------------- | ---------------------------------------------- |
| XXXEndAfter    | Is the thing still there after several seconds |
| XXXEndAfterGCD | Is the thing still there after several gcds.   |



## Record(Not Recommend)

| Property            | Description                                                  |
| ------------------- | ------------------------------------------------------------ |
| RecordActions       | Actions successfully released. The first one is the latest one. |
| TimeSinceLastAction | How much time has passed since the last action was released. |

In methods, we always have two parameters.

isAdjust: Check for adjust id not raw id.

actions or ids: True if any of this is matched.

| Methods           | Description                                   |
| ----------------- | --------------------------------------------- |
| IsLastGCD         | Check for GCD Record.                         |
| IsLastAbility     | Check for ability Record.                     |
| IsLastAction      | Check for action Record.                      |
| CombatElapsedLess | Check  how long the battle has been going on. |

# Action

Another very important source of information is action.

## Basic

| Property    | Description            |
| ----------- | ---------------------- |
| EnoughLevel | EnoughLevel for using. |

## Target

| Property      | Description                    |
| ------------- | ------------------------------ |
| Target        | The action's target.           |
| IsTargetDying | Shortcut for Target.IsDying(); |
| IsTargetBoss  | Shortcut for Target.IsBoss();  |

## CoolDown

| Property       | Description             |
| -------------- | ----------------------- |
| IsCoolingDown  | Is action cooling down. |
| CurrentCharges | Current charges count.  |
| MaxCharges     | Max charges count.      |

| Method               | Description                                  |
| -------------------- | -------------------------------------------- |
| ElapsedAfterGCD      | Has it been in cooldown for so long?         |
| ElapsedAfter         | Has it been in cooldown for so long?         |
| WillHaveOneChargeGCD | Will have at least one charge after a while? |
| WillHaveOneCharge    | Will have at least one charge after a while? |

# Character

The last source of information is character. Very important.

## Basic

| Method         | Description                                                  |
| -------------- | ------------------------------------------------------------ |
| IsBoss         | Is character a boss? Max HP exceeds a certain amount.        |
| IsDying        | Is character a dying? Current HP is below a certain amount. It is for running out of resources. |
| GetHealthRatio | Get the target's current HP percentage.                      |

## Status

| Method           | Description                              |
| ---------------- | ---------------------------------------- |
| WillStatusEndGCD | Will any of status be end after a while? |
| WillStatusEnd    | Will any of status be end after a while? |
| HasStatus        | Has one status right now.                |

