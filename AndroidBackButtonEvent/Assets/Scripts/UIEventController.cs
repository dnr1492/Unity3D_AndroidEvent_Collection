using UnityEngine;

public class UIEventController : MonoBehaviour
{
    private float clickCount = 0;  //뒤로 가기 버튼 클릭 횟수
    private int resetWaitingTime = 1;  //뒤로 가기 버튼 클릭 횟수 초기화 대기 시간

    public void InitUIEvent()
    {
        QuitAndroidApp();
    }

    /// <summary>
    /// 안드로이드 휴대폰의 뒤로 가기 버튼 두 번 클릭 시 앱 종료
    /// </summary>
    private void QuitAndroidApp()
    {
        //안드로이드 플랫폼이라면
        if (Application.platform == RuntimePlatform.Android)  
        {
            //GetKeyDown (눌렀을 때)
            if (Input.GetKeyDown(KeyCode.Escape))  
            {
                clickCount++;
                if (!IsInvoking("ResetClickCount"))
                {
                    Invoke("ResetClickCount", resetWaitingTime);
                }
                //두 번 클릭 시 앱 종료
                else if (clickCount == 2)
                {
                    CancelInvoke("ResetClickCount");
                    Application.Quit();
                }
            }
        }
    }

    /// <summary>
    /// 뒤로 가기 버튼 클릭 횟수 초기화
    /// </summary>
    private void ResetClickCount()
    {
        clickCount = 0;
    }
}
