using System.Collections.Generic;
using static WeaponThread.WeaponStructure;
using static WeaponThread.WeaponStructure.WeaponDefinition;
using static WeaponThread.WeaponStructure.WeaponDefinition.HardPointDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.ModelAssignmentsDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.HardPointDef.HardwareDef.ArmorState;
using static WeaponThread.WeaponStructure.WeaponDefinition.HardPointDef.Prediction;
using static WeaponThread.WeaponStructure.WeaponDefinition.TargetingDef.BlockTypes;
using static WeaponThread.WeaponStructure.WeaponDefinition.TargetingDef.Threat;

namespace WeaponThread {   
    partial class Weapons {
		// Don't edit above this line
        WeaponDefinition RetractLeftPDCgatling => new WeaponDefinition
        {
            Assignments = new ModelAssignmentsDef
            {
                MountPoints = new[]
                {
                    new MountPointDef {
                        SubtypeId = "MCRNLeftRetractPDC",
                        AimPartId = "",
                        MuzzlePartId = "Leftbarrels",
                        AzimuthPartId = "LeftPDCAzi",
                        ElevationPartId = "LeftPDCEle",
                        DurabilityMod = 0.25f,
                        IconName = "TestIcon.dds"
                    },

                },
                Barrels = new []
                {
                    "muzzle_barrel_001",
                    "muzzle_barrel_002",
                    "muzzle_barrel_003",
                    "muzzle_barrel_004",
                    "muzzle_barrel_005",
                    "muzzle_barrel_006",
                },
            },
            Targeting = new TargetingDef
            {
                Threats = new[]
                {
                    Grids, Characters, Projectiles, Meteors, // threats percieved automatically without changing menu settings
                },
                SubSystems = new[]
                {
                    Thrust, Utility, Offense, Power, Production, Any, // subsystems the gun targets
                },
                ClosestFirst = true, // tries to pick closest targets first (blocks on grids, projectiles, etc...).
                IgnoreDumbProjectiles = false, // Don't fire at non-smart projectiles.
                LockedSmartOnly = false, // Only fire at smart projectiles that are locked on to parent grid.
                MinimumDiameter = 0, // 0 = unlimited, Minimum radius of threat to engage.
                MaximumDiameter = 0, // 0 = unlimited, Maximum radius of threat to engage.
                MaxTargetDistance = 0, // 0 = unlimited, Maximum target distance that targets will be automatically shot at.
                MinTargetDistance = 0, // 0 = unlimited, Min target distance that targets will be automatically shot at.
                TopTargets = 4, // 0 = unlimited, max number of top targets to randomize between.
                TopBlocks = 4, // 0 = unlimited, max number of blocks to randomize between
                StopTrackingSpeed = 1000, // do not track target threats traveling faster than this speed
            },
            HardPoint = new HardPointDef
            {
                WeaponName = "LeftRetractPDC", // name of weapon in terminal
                DeviateShotAngle = 0.3f,
                AimingTolerance = 4f, // 0 - 180 firing angle
                AimLeadingPrediction = Advanced, // Off, Basic, Accurate, Advanced
                DelayCeaseFire = 10, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                AddToleranceToTracking = false,
                CanShootSubmerged = false,

                Ui = new UiDef
                {
                    RateOfFire = true,
                    DamageModifier = false,
                    ToggleGuidance = false,
                    EnableOverload =  false,
                },
                Ai = new AiDef
                {
                    TrackTargets = true,
                    TurretAttached = true,
                    TurretController = true,
                    PrimaryTracking = true,
                    LockOnFocus = false,
                },
                HardWare = new HardwareDef
                {
                    RotateRate = 0.03f,
                    ElevateRate = 0.03f,
                    MinAzimuth = -180,
                    MaxAzimuth = 180,
                    MinElevation = -20,
                    MaxElevation = 90,
                    FixedOffset = false,
                    InventorySize = 0.800f,
                    Offset = Vector(x: 0, y: 0, z: 0),
                    Armor = IsWeapon, // IsWeapon, Passive, Active
                },
                Other = new OtherDef
                {
                    GridWeaponCap = 0, // 0=disabled
                    RotateBarrelAxis = 3,
                    EnergyPriority = 0,
                    MuzzleCheck = false,
                    Debug = false,
                },
                Loading = new LoadingDef
                {
                    RateOfFire = 2600,
                    BarrelsPerShot = 1,
                    TrajectilesPerBarrel = 1, // Number of Trajectiles per barrel per fire event.
                    SkipBarrels = 0,
                    ReloadTime = 240, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    DelayUntilFire = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    HeatPerShot = 4, //heat generated per shot
                    MaxHeat = 3000, //max heat before weapon enters cooldown (70% of max heat)
                    Cooldown = .75f, //percent of max heat to be under to start firing again after overheat accepts .2-.95
                    HeatSinkRate = 130, //amount of heat lost per second
                    DegradeRof = false, // progressively lower rate of fire after 80% heat threshold (80% of max heat)
                    ShotsInBurst = 0,
                    DelayAfterBurst = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    FireFullBurst = false,
                    GiveUpAfterBurst = false,
                    BarrelSpinRate = 2600, // visual only, 0 disables and uses RateOfFire
                
                },
                Audio = new HardPointAudioDef
                {
                    PreFiringSound = "",
                    FiringSound = "WepTurretInteriorFire", // subtype name from sbc
                    FiringSoundPerShot = true,
                    ReloadSound = "",
                    NoAmmoSound = "",
                    HardPointRotationSound = "WepTurretGatlingRotate",
                    BarrelRotationSound = "",
                    FireSoundEndDelay = 120, // Measured in game ticks(6 = 100ms, 60 = 1 seconds, etc..).
                },
                Graphics = new HardPointParticleDef
                {
                    Barrel1 = new ParticleDef
                    {
                        Name = "Smoke_LargeGunShot", // Smoke_LargeGunShot
                        Color = Color(red: 1, green: 1, blue: 1, alpha: 1),
                        Offset = Vector(x: 0, y: 0, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = false,
                            Restart = false,
                            MaxDistance = 200,
                            MaxDuration = 1,
                            Scale = 1.0f,
                        },
                    },
                    Barrel2 = new ParticleDef
                    {
                        Name = "Muzzle_Flash_PDC",//Muzzle_Flash_Large
                        Color = Color(red: 1, green: 1, blue: 1, alpha: 1),
                        Offset = Vector(x: 0, y: 0, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = false,
                            Restart = false,
                            MaxDistance = 200,
                            MaxDuration = 1,
                            Scale = 1f,
                        },
                    },
                },
            },
       
			Ammos = new [] {
                NATO_Ammo,
                NDeU_Ammo
				
            },
            Animations = LeftRetractPDCAnims,
            // Don't edit below this line
        };
    }
}