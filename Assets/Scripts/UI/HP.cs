using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    [SerializeField] Slider sliderController;
    [SerializeField] TMPro.TMP_Text score;

    private void OnEnable()
    {
        CollisionDetect.OnCollision += ChangeSliderValue;
        Med.OnCollision += ChangeSliderValue2;
        CollisionDetectEnemy.OnCollision += ScoreIncrement;
    }

    private void OnDisable()
    {
        CollisionDetect.OnCollision -= ChangeSliderValue;
        Med.OnCollision -= ChangeSliderValue2;
        CollisionDetectEnemy.OnCollision -= ScoreIncrement;
    }

    public void ChangeSliderValue()
    {
        sliderController.value--;
    }

    public void ChangeSliderValue2()
    {
        sliderController.value = sliderController.maxValue;
    }

    public void ScoreIncrement()
    {
        score.text = $"{GameManager.Instance.Score}";
    }
}
