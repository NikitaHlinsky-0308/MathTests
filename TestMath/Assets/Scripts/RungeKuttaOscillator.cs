using UnityEngine;

public class RungeKuttaOscillator : MonoBehaviour
{
    public float angularFrequency = 2.0f; // Омега (угловая частота)
    public float timeStep = 0.02f; // Шаг времени
    public float amplitude = 1.0f; // Начальная амплитуда

    private float position; // Текущее положение
    private float velocity; // Текущая скорость

    void Start()
    {
        position = amplitude; // Начальная амплитуда
        velocity = 0; // Начальная скорость
    }

    void Update()
    {
        RungeKuttaIntegration(ref position, ref velocity, timeStep);

        // Применяем движение к объекту
        transform.position = new Vector3(position, 0, 0);
    }

    void RungeKuttaIntegration(ref float pos, ref float vel, float dt)
    {
        // k1
        float k1_v = -angularFrequency * angularFrequency * pos;
        float k1_p = vel;

        // k2
        float k2_v = -angularFrequency * angularFrequency * (pos + 0.5f * dt * k1_p);
        float k2_p = vel + 0.5f * dt * k1_v;

        // k3
        float k3_v = -angularFrequency * angularFrequency * (pos + 0.5f * dt * k2_p);
        float k3_p = vel + 0.5f * dt * k2_v;

        // k4
        float k4_v = -angularFrequency * angularFrequency * (pos + dt * k3_p);
        float k4_p = vel + dt * k3_v;

        // Обновляем значения
        vel += (dt / 6.0f) * (k1_v + 2.0f * k2_v + 2.0f * k3_v + k4_v);
        pos += (dt / 6.0f) * (k1_p + 2.0f * k2_p + 2.0f * k3_p + k4_p);
    }
}