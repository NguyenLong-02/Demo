using UnityEngine;

namespace Assets.Script.Play_Game
{
    public class CameraMoving : MonoBehaviour
    {
        [SerializeField] private Camera cam;
        [SerializeField] private Transform Player;   
        [SerializeField] private Transform Island;
        [SerializeField] private Transform target;
        [SerializeField] private float distanceToTarget = 3;
        [SerializeField] private Animator anim;
        [SerializeField] GameObject Anim;
        [SerializeField] UIGAME ISCameraFormAbove;

        [SerializeField] float minY, maxY;

        public float time_preview = 20;
        private float camera_speed = 15;

        [SerializeField] Transform CameraTransFormAbove;
        Vector3 previousPosition;
        public bool isPreview = true;

        private void Start()
        {
            Anim.SetActive(false);
        }

        private void LateUpdate()
        {
            #region Movie DEvice
            /*            if (Input.touchCount > 0)
                        {
                            foreach (Touch touch in Input.touches)
                            {
                                if (touch.phase == TouchPhase.Began)
                                {
                                    previousPosition = touch.position;
                                }
                                else if (touch.phase == TouchPhase.Moved)
                                {
                                    Vector3 newPosition = touch.position;
                                    Vector3 direction = previousPosition - newPosition;

                                    float rotationAroundYAxis = direction.x * 90; // camera moves horizontally
                                    float rotationAroundXAxis = direction.y * 90; // camera moves vertically

                                    cam.transform.position = target.position;

                                    cam.transform.Rotate(new Vector3(1, 0, 0), rotationAroundXAxis);
                                    cam.transform.Rotate(new Vector3(0, 1, 0), -rotationAroundYAxis, Space.World);

                                    cam.transform.Translate(new Vector3(0, 0, -distanceToTarget * 30));

                                    previousPosition = newPosition;
                                }
                                else if (touch.phase == TouchPhase.Ended) previousPosition = new Vector3();
                            }
                        }
                        else
                        {
                            cam.transform.position = target.position;

                            cam.transform.Rotate(new Vector3(0, 1, 0), 15 * Time.deltaTime, Space.World);
                            // Space.World ở đây là trúng ta đang Rotate theo trục của cái đất là Global
                            // Còn nếu không để Space.World ở đây thì chúng ta chỉ đang Rotate theo trục Local Của Obejct
                            //*
                            cam.transform.Translate(new Vector3(0, 0, -distanceToTarget * 30) , Space.World);
                            cam.transform.Translate(new Vector3(0, 0, -distanceToTarget * 30));

                            // Ở đây là Translate theo Local Axis nên lúc kéo theo tọa Tương ứng, Với dòng code trên thì Translate đc tính theo Z, 
                            // Vậy nên lúc ở trong Scene ta kéo Camera theo Z Theo hướng gần tới Object đã gán (cam.transform.position = target.position)
                            // Thì ta thấy tọa độ của nó tăng lên, nhưng chúng ta muốn thấy đc toàn bộ đảo thì ta phải để số âm nên lúc này Camera của ta
                            // Sẽ Translate theo âm trục so với Z và nó sẽ tiến ra xa để thấy đc toàn bộ đảo
                        }//**/
            #endregion

            #region PC Device

            if(isPreview)
            {
                time_preview -= Time.deltaTime;
                if (time_preview < 13.5 && time_preview > 12)
                {
                    Anim.SetActive(true);
                    anim.SetFloat("Time", time_preview);
                }
                if (time_preview < 13) target = Island;
                if (time_preview < 5.3) target = Player;
                if (time_preview < 0) isPreview = false;
            }
            
            if (!isPreview)
            {
                target = Island;
                distanceToTarget = 7f;
                camera_speed = 5f;

                #region Thực hiện lúc CameraView Đang ở vị trí xoay Đều
                if (Input.GetMouseButtonDown(0) && ISCameraFormAbove.CameraFormAbove == false)
                {
                    previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
                }
                else if (Input.GetMouseButton(0) && ISCameraFormAbove.CameraFormAbove == false)
                {
                    Vector3 newPosition = cam.ScreenToViewportPoint(Input.mousePosition);
                    Vector3 direction = previousPosition - newPosition;

                    float rotationAroundYAxis = direction.x * 90; // camera moves vertically
                    float rotationAroundXAxis = direction.y * 90; // camera moves horizontally

                    cam.transform.position = target.position;


                    cam.transform.Rotate(new Vector3(1, 0, 0), rotationAroundXAxis); // Xoay theo trục Local của Obejct
                    cam.transform.Rotate(new Vector3(0, 1, 0), -rotationAroundYAxis, Space.World); // Xoay Theo trục của thế giới
                    cam.transform.Translate(new Vector3(0, 0, -distanceToTarget * 40)); // Dịch chuyển theo trục z theo local
                    previousPosition = newPosition; // Tại vì lúc này vẫn đang giữ nên câu lệnh GetMoustButton vẫn sẽ thực hiện
                    // Vì vậy ta tiếp tục gán lại biến previousPosition = newPosition cũ, để cho câu lệnh tiêp thục thực hiện với một
                    // newPosition mới
                }
                if (ISCameraFormAbove.CameraFormAbove == false)
                {
                    cam.transform.position = target.position;
                    cam.transform.Rotate(new Vector3(0, 1, 0), camera_speed * Time.deltaTime, Space.World);
                    // Space.World ở đây là trúng ta đang Rotate theo trục của cái đất là Global
                    // Còn nếu không để Space.World ở đây thì chúng ta chỉ đang Rotate theo trục Local Của Obejct
                    cam.transform.Translate(new Vector3(0, 0, -distanceToTarget * 40));
                    // cam.transform.Translate(new Vector3(0, 0, -distanceToTarget * 30), Space.World);

                    // Ở đây là Translate theo Local Axis nên lúc kéo theo tọa Tương ứng, Với dòng code trên thì Translate đc tính theo Z, 
                    // Vậy nên lúc ở trong Scene ta kéo Camera theo Z Theo hướng gần tới Object đã gán (cam.transform.position = target.position)
                    // Thì ta thấy tọa độ của nó tăng lên, nhưng chúng ta muốn thấy đc toàn bộ đảo thì ta phải để số âm nên lúc này Camera của ta
                    // Sẽ Translate theo âm trục so với Z và nó sẽ tiến ra xa để thấy đc toàn bộ đảo
                }

                #endregion

                #region Thực hiện lúc CameraView Đang ở Above
                if (Input.GetMouseButtonDown(0) && ISCameraFormAbove.CameraFormAbove == true)
                {
                    previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
                }
                else if (Input.GetMouseButton(0) && ISCameraFormAbove.CameraFormAbove == true)
                {

                    // Giới hạn Vị trí của camera

                    cam.transform.position = new Vector3(Mathf.Clamp(transform.position.x, -100.3612f, 67.9052f),
                        transform.position.y,
                        Mathf.Clamp(transform.position.z, 112.6953f - 300f, 516.8707f-300f));

                    // Tính tọa độ chuột mới so với chuột cũ và hướng của nó
                    Vector3 newPosition = cam.ScreenToViewportPoint(Input.mousePosition);
                    Vector3 direction = previousPosition - newPosition;

                    cam.transform.Translate(new Vector3(direction.x*100, direction.y*100, 0));
                    // Lúc này ta đang dịch chuyển camera theo trục x và y theo kiểu Local là theo trục của Object
                    // THeo một khoảng giá trị nào đó tính theo direction là hướng vector của vị trí chuột cũ và mới

                    previousPosition = newPosition;
                }
                #endregion
            }
            else
            {
                cam.transform.position = target.position;
                cam.transform.Rotate(new Vector3(0, 1, 0), camera_speed * Time.deltaTime, Space.World);
                // Space.World ở đây là trúng ta đang Rotate theo trục của cái đất là Global
                // Còn nếu không để Space.World ở đây thì chúng ta chỉ đang Rotate theo trục Local Của Obejct
                cam.transform.Translate(new Vector3(0, 0, -distanceToTarget * 40));
                // cam.transform.Translate(new Vector3(0, 0, -distanceToTarget * 30), Space.World);

                // Ở đây là Translate theo Local Axis nên lúc kéo theo tọa Tương ứng, Với dòng code trên thì Translate đc tính theo Z, 
                // Vậy nên lúc ở trong Scene ta kéo Camera theo Z Theo hướng gần tới Object đã gán (cam.transform.position = target.position)
                // Thì ta thấy tọa độ của nó tăng lên, nhưng chúng ta muốn thấy đc toàn bộ đảo thì ta phải để số âm nên lúc này Camera của ta
                // Sẽ Translate theo âm trục so với Z và nó sẽ tiến ra xa để thấy đc toàn bộ đảo
            }
            #endregion

        }
    }
}
