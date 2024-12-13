using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public Transform target;  // Цель, которую нужно проверить
    public float viewAngle = 90f; // Угол обзора персонажа
    public float viewDistance = 10f; // Дистанция обзора

    void OnDrawGizmos()
    {
        // Нарисовать поле зрения
        Gizmos.color = Color.yellow;
        Vector3 forward = transform.forward * viewDistance;

        // Левая и правая границы обзора
        Vector3 leftBoundary = Quaternion.Euler(0, -viewAngle / 2, 0) * forward;
        Vector3 rightBoundary = Quaternion.Euler(0, viewAngle / 2, 0) * forward;

        // Центр и границы обзора
        Gizmos.DrawRay(transform.position, forward);
        Gizmos.DrawRay(transform.position, leftBoundary);
        Gizmos.DrawRay(transform.position, rightBoundary);

        // Если цель есть
        if (target != null)
        {
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            float dot = Vector3.Dot(transform.forward, directionToTarget);

            // Проверяем, в поле зрения ли цель
            float angleToTarget = Mathf.Acos(dot) * Mathf.Rad2Deg;
            if (dot > Mathf.Cos(viewAngle / 2f * Mathf.Deg2Rad))
            {
                Gizmos.color = Color.green; // Если цель видна
            }
            else
            {
                Gizmos.color = Color.red; // Если цель вне поля зрения
            }

            // Линия до цели
            Gizmos.DrawLine(transform.position, target.position);

            // Вывод угла
            Debug.Log($"Angle to target: {angleToTarget} degrees");
        }
    }
}
