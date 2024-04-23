using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    [SerializeField] GameObject leftKunai;
    [SerializeField] GameObject rightKunai;
    [SerializeField] GameObject leftSakura;
    [SerializeField] GameObject rightSakura;
    [SerializeField] GameObject gate;
    [SerializeField] GameObject fuji;
    void Start()
    {
        // Sakura Animation
        Vector2 InitialPosLeftSakura = leftSakura.transform.localPosition;
        Vector2 InitialPosRightSakura = rightSakura.transform.localPosition;

        leftSakura.transform.localPosition = new Vector2 (-Screen.width, InitialPosLeftSakura.y);
        leftSakura.LeanMoveLocal(InitialPosLeftSakura, 0.6f).setEaseInOutSine();

        rightSakura.transform.localPosition = new Vector2 (Screen.width, InitialPosLeftSakura.y);
        rightSakura.LeanMoveLocal(InitialPosRightSakura, 0.6f).setEaseInOutSine();

        // Gate Animation
        Vector2 InitialGatePosition = gate.transform.localPosition;
        gate.transform.localPosition = new Vector2(InitialGatePosition.x, Screen.height);
        gate.LeanMoveLocal(InitialGatePosition, 0.6f).setEaseInCubic();

        // Fuji Animation
        Vector2 InitialFujiPosition = fuji.transform.localPosition;
        fuji.transform.localPosition = new Vector2(InitialFujiPosition.x, -Screen.height);
        fuji.LeanMoveLocal(InitialFujiPosition, 0.6f).setEaseOutSine();

        //Kunai Animation
        Vector2 InitialPosLeftKunai = leftKunai.transform.localPosition;
        Vector2 InitialPosRightKunai = rightKunai.transform.localPosition;

        leftKunai.transform.localPosition = new Vector2(-Screen.width, InitialPosLeftKunai.y);
        leftKunai.LeanMoveLocal(InitialPosLeftKunai, 1.3f).setEaseInOutSine();

        rightKunai.transform.localPosition = new Vector2(Screen.width, InitialPosLeftKunai.y);
        rightKunai.LeanMoveLocal(InitialPosRightKunai, 1.3f).setEaseInOutSine();
    }


}
