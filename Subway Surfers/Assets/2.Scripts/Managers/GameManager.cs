using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text squareText;
    [SerializeField] private Text goldText;
    public GameObject diePanel;
    private int score;
    public int square = 1;
    public int gold = 0;

    private int width = 1080;
    private int height = 1920;

    private void Awake()
    {
        instance = this;

        Screen.SetResolution(width, height, true);
    }

    void Start()
    {
        scoreText.text = $"{score}";
        squareText.text = $"x{square}";
        goldText.text = $"{gold}";
    }

    void FixedUpdate()
    {
        score += Mathf.Clamp(square, 1, 20);

        ScoreUpdate();
        SquareUpdate();
        GoldUpdate();
    }

    void ScoreUpdate() => scoreText.text = $"{score}";

    void SquareUpdate() => squareText.text = $"x{square = Mathf.Clamp(square, 1, 20)}";

    void GoldUpdate() => goldText.text = $"{gold}";
}
