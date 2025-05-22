using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class RightHandController : MonoBehaviour
{
    //Estado
    public InputActionReference Joystick_North_Reference;

    // Right Controller - grab
    public ActionBasedController actionBasedController_grab;
    public XRRayInteractor xrRayInteractor_grab;
    public LineRenderer lineRenderer_grab;
    public XRInteractorLineVisual xrInteractorLineVisual_grab;

    // Right Controller - teleport
    public ActionBasedController actionBasedController_teleport;
    public XRRayInteractor xrRayInteractor_teleport;
    public LineRenderer lineRenderer_teleport;
    public XRInteractorLineVisual xrInteractorLineVisual_teleport;

    //Metodos Propios

    private void JoyStickArribaPresionado(InputAction.CallbackContext context)
    {
        xrRayInteractor_grab.enabled = false;


        xrRayInteractor_teleport.enabled = true;
        xrInteractorLineVisual_teleport.enabled = true;
    }

    private void JoyStickArribaLiberado(InputAction.CallbackContext context)
    {
        xrRayInteractor_grab.enabled = true;

        
        xrRayInteractor_teleport.enabled = false;
        xrInteractorLineVisual_teleport.enabled = false;
    }


    private void OnEnable()
    {
        Joystick_North_Reference.action.performed += JoyStickArribaPresionado;
        Joystick_North_Reference.action.canceled += JoyStickArribaLiberado;
    }


    public void OnDisable()
    {
        Joystick_North_Reference.action.performed -= JoyStickArribaPresionado;
        Joystick_North_Reference.action.canceled -= JoyStickArribaLiberado;
    }

}
