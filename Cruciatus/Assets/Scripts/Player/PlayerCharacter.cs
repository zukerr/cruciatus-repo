using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public static PlayerCharacter instance;

    [SerializeField]
    private DamagableObject damagablePlayer = null;
    [SerializeField]
    private SpiritHandler spiritModule = null;
    [SerializeField]
    private IgnitionHandler ignitionModule = null;
    [SerializeField]
    private PlayerApplicableDurationEffects buffsModule = null;
    [SerializeField]
    private PlayerApplicableDurationEffects debuffsModule = null;
    [SerializeField]
    private PlayerCooldowns cooldownsModule = null;
    [SerializeField]
    private PlayerStats statsModule = null;

    public DamagableObject DamagablePlayer => damagablePlayer;
    public PlayerBasicAttack BasicAttackModule { get; private set; }
    public PlayerSpellcasting SpellcastingModule { get; private set; }
    public SpiritHandler SpiritModule => spiritModule;
    public IgnitionHandler IgnitionModule => ignitionModule;
    public PlayerApplicableDurationEffects BuffsModule => buffsModule;
    public PlayerApplicableDurationEffects DebuffsModule => debuffsModule;
    public PlayerCooldowns CooldownsModule => cooldownsModule;
    public PlayerMovement MovementModule { get; private set; }
    public PlayerControls ControlsModule { get; private set; }
    public PlayerStats StatsModule => statsModule;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        BasicAttackModule = GetComponent<PlayerBasicAttack>();
        SpellcastingModule = GetComponent<PlayerSpellcasting>();
        MovementModule = GetComponent<PlayerMovement>();
        ControlsModule = GetComponent<PlayerControls>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
