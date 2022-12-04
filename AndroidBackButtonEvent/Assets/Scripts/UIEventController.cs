using UnityEngine;

public class UIEventController : MonoBehaviour
{
    private float clickCount = 0;  //�ڷ� ���� ��ư Ŭ�� Ƚ��
    private int resetWaitingTime = 1;  //�ڷ� ���� ��ư Ŭ�� Ƚ�� �ʱ�ȭ ��� �ð�

    public void InitUIEvent()
    {
        QuitAndroidApp();
    }

    /// <summary>
    /// �ȵ���̵� �޴����� �ڷ� ���� ��ư �� �� Ŭ�� �� �� ����
    /// </summary>
    private void QuitAndroidApp()
    {
        //�ȵ���̵� �÷����̶��
        if (Application.platform == RuntimePlatform.Android)  
        {
            //GetKeyDown (������ ��)
            if (Input.GetKeyDown(KeyCode.Escape))  
            {
                clickCount++;
                if (!IsInvoking("ResetClickCount"))
                {
                    Invoke("ResetClickCount", resetWaitingTime);
                }
                //�� �� Ŭ�� �� �� ����
                else if (clickCount == 2)
                {
                    CancelInvoke("ResetClickCount");
                    Application.Quit();
                }
            }
        }
    }

    /// <summary>
    /// �ڷ� ���� ��ư Ŭ�� Ƚ�� �ʱ�ȭ
    /// </summary>
    private void ResetClickCount()
    {
        clickCount = 0;
    }
}
