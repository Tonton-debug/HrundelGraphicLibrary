using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;
namespace TestGame
{
    public class EnemyCreator
    {

        private List<Enemy> _enemies=new  List<Enemy>();
        private float _tick = 0;
        private readonly float _minTime = 0.5f;
        private float _time = 5;
        private float _interval = 0.2f;
        public EnemyCreator()
        {

        }
        private void CreateEnemy()
        {

        }
        
        
        Random _random = new Random();
        public void Update(float dt)
        {

            _tick += dt;
            if (_tick >= _time)
            {
                _tick = 0;
                _interval = _random.Next(1, 10) * 0.1f;
                _time = _time - _interval < _minTime ? _time+ _interval : _time - _interval;
                _enemies.Add(new Enemy(new Vector3(_random.Next(-10, 10), 10, _random.Next(-600, -500))));
            }
        }
    }
}
