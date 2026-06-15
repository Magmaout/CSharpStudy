using System.Collections.Generic;

namespace CSharpStudy {
    internal static class C_pract_02 {
        public static void Run() {
            while (true) {
                InputHelper.ClearConsole();
                Console.WriteLine("Практика 2 \"Симуляция модулей\":");
                Console.WriteLine("1. \"Тестирование Coord\";");
                Console.WriteLine("2. \"Тестирование модулей\";");
                Console.WriteLine("3. \"Тестирование SimulationEngine\";");
                Console.WriteLine("4. \"Запустить все тесты\";");
                Console.WriteLine("0. \"Выбор урока\".");

                try {
                    switch (InputHelper.GetMenuPositiveInteger("\nВведите номер задания (0 - выбор урока): ", "0, 1, 2, 3 или 4")) {
                        case 0:
                            return;
                        case 1:
                            TestCoord();
                            break;
                        case 2:
                            TestModules();
                            break;
                        case 3:
                            TestSimulationEngine();
                            break;
                        case 4:
                            RunAllTests();
                            break;
                        default:
                            Console.WriteLine("Задания с таким номером не существует!");
                            break;
                    }
                } catch (TaskResetException) {
                    continue;
                }
                if (!InputHelper.AskContinue("Продолжить работу с практикой?")) break;
            }
        }

        static void TestCoord() {
            Console.WriteLine("\n=== Тестирование Coord ===");
            var c1 = new Coord(2, 5);
            var c2 = new Coord(1, -3);
            var sum = c1 + c2;
            var diff = c1 - c2;
            var scaled = c1 * 3;
            Console.WriteLine($"c1: ({c1.X}, {c1.Y})");
            Console.WriteLine($"c2: ({c2.X}, {c2.Y})");
            Console.WriteLine($"c1 + c2: ({sum.X}, {sum.Y})");
            Console.WriteLine($"c1 - c2: ({diff.X}, {diff.Y})");
            Console.WriteLine($"c1 * 3: ({scaled.X}, {scaled.Y})");
            Console.WriteLine($"c1 == c2: {c1 == c2}");
            Console.WriteLine($"c1.Equals(c1): {c1.Equals(c1)}");
            Console.WriteLine($"c1.GetHashCode(): {c1.GetHashCode()}");
        }

        static void TestModules() {
            Console.WriteLine("\n=== Тестирование модулей ===");
            AbstractModule scout = new ScoutModule(new Coord(0, 0), 10);
            AbstractModule cargo = new CargoModule(new Coord(5, 5), 10);
            Console.WriteLine("ScoutModule:");
            scout.Act();
            Console.WriteLine("CargoModule:");
            cargo.Act();
        }

        static void TestSimulationEngine() {
            Console.WriteLine("\n=== Тестирование SimulationEngine ===");
            var engine = new SimulationEngine();
            var map = new AbstractModule[3][];
            map[0] = new AbstractModule[] { new ScoutModule(new Coord(0, 0), 100), null };
            map[1] = new AbstractModule[] { new CargoModule(new Coord(1, 1), 100), new ScoutModule(new Coord(2, 2), 100) };
            map[2] = null;

            int fuel = 0;
            bool res = engine.TryStep(map, 0, out int processed, ref fuel);
            Console.WriteLine($"Результат: {res}");
            Console.WriteLine($"Обработано модулей: {processed}");
            Console.WriteLine($"Топливо после: {fuel}");
        }

        static void RunAllTests() {
            Console.WriteLine("\n=== Запуск всех тестов ===");
            int passed = 0;
            int failed = 0;

            // Test Coord Operators
            try {
                var c1 = new Coord(2, 5);
                var c2 = new Coord(1, -3);
                Assert.AreEqual(new Coord(3, 2), c1 + c2, "Оператор '+' возвращает неверный результат");
                Assert.AreEqual(new Coord(1, 8), c1 - c2, "Оператор '-' возвращает неверный результат");
                Assert.AreEqual(new Coord(6, 15), c1 * 3, "Оператор '*' (скаляр) возвращает неверный результат");
                passed++;
                Console.WriteLine("✅ [PASS] Test_Coord_Operators");
            } catch (TestFailureException ex) {
                failed++;
                Console.WriteLine($"❌ [FAIL] Test_Coord_Operators: {ex.Message}");
            }

            // Test Coord Equality and Hash
            try {
                var a = new Coord(7, 7);
                var b = new Coord(7, 7);
                var c = new Coord(7, 8);
                Assert.IsTrue(a == b, "Оператор '==' должен возвращать true для идентичных координат");
                Assert.IsTrue(a != c, "Оператор '!=' должен возвращать true для разных координат");
                Assert.IsTrue(a.Equals(b), "Метод Equals должен возвращать true для равных структур");
                Assert.IsFalse(a.Equals(null), "Equals(null) должен возвращать false");
                Assert.AreEqual(a.GetHashCode(), b.GetHashCode(), "Хэш-коды равных структур обязаны совпадать");
                passed++;
                Console.WriteLine("✅ [PASS] Test_Coord_EqualityAndHashContract");
            } catch (TestFailureException ex) {
                failed++;
                Console.WriteLine($"❌ [FAIL] Test_Coord_EqualityAndHashContract: {ex.Message}");
            }

            // Test Module Creation and Polymorphism
            try {
                AbstractModule scout = new ScoutModule(new Coord(0, 0), 10);
                AbstractModule cargo = new CargoModule(new Coord(5, 5), 10);
                scout.Act();
                cargo.Act();
                Assert.IsTrue(true, "Полиморфный вызов Act() выполнен без исключений");
                passed++;
                Console.WriteLine("✅ [PASS] Test_Module_CreationAndPolymorphism");
            } catch (TestFailureException ex) {
                failed++;
                Console.WriteLine($"❌ [FAIL] Test_Module_CreationAndPolymorphism: {ex.Message}");
            }

            // Test Engine Empty and Null Maps
            try {
                var engine = new SimulationEngine();
                int fuel1 = 0;
                bool res1 = engine.TryStep(new AbstractModule[0][], 0, out int cnt1, ref fuel1);
                Assert.IsFalse(res1, "Пустая карта должна возвращать false");
                Assert.AreEqual(0, cnt1, "Количество обработанных на пустой карте должно быть 0");
                var mapWithNulls = new AbstractModule[2][] { null, new AbstractModule[0] };
                int fuel2 = 0;
                bool res2 = engine.TryStep(mapWithNulls, 0, out int cnt2, ref fuel2);
                Assert.IsFalse(res2, "Карта из null/пустых строк должна возвращать false");
                Assert.AreEqual(0, cnt2, "Количество обработанных должно быть 0");
                passed++;
                Console.WriteLine("✅ [PASS] Test_Engine_EmptyAndNullMaps");
            } catch (TestFailureException ex) {
                failed++;
                Console.WriteLine($"❌ [FAIL] Test_Engine_EmptyAndNullMaps: {ex.Message}");
            }

            // Test Engine ProcessedCount Accuracy
            try {
                var engine = new SimulationEngine();
                var map = new AbstractModule[3][];
                map[0] = new AbstractModule[] { new ScoutModule(new Coord(0, 0), 100), null };
                map[1] = new AbstractModule[] { new CargoModule(new Coord(1, 1), 100), new ScoutModule(new Coord(2, 2), 100) };
                map[2] = null;

                int fuel = 0;
                bool res = engine.TryStep(map, 0, out int processed, ref fuel);
                Assert.IsTrue(res, "Наличие модулей должно возвращать true");
                Assert.AreEqual(3, processed, "Счётчик processed должен точно соответствовать количеству не-null модулей");
                passed++;
                Console.WriteLine("✅ [PASS] Test_Engine_ProcessedCountAccuracy");
            } catch (TestFailureException ex) {
                failed++;
                Console.WriteLine($"❌ [FAIL] Test_Engine_ProcessedCountAccuracy: {ex.Message}");
            }

            // Test Engine Out and Ref Contract
            try {
                var engine = new SimulationEngine();
                var map = new AbstractModule[1][] { new AbstractModule[] { new ScoutModule(new Coord(0, 0), 10) } };
                int outParam = -999;
                int refParam = 50;
                engine.TryStep(map, 0, out outParam, ref refParam);
                Assert.AreEqual(1, outParam, "out-параметр должен быть инициализирован методом");
                Assert.IsTrue(refParam != 50, "ref-параметр должен быть изменён внутри метода");
                passed++;
                Console.WriteLine("✅ [PASS] Test_Engine_OutAndRefContract");
            } catch (TestFailureException ex) {
                failed++;
                Console.WriteLine($"❌ [FAIL] Test_Engine_OutAndRefContract: {ex.Message}");
            }

            // Test Sealed Classes
            try {
                Assert.IsTrue(typeof(ScoutModule).IsSealed, "ScoutModule должен быть объявлен как sealed");
                Assert.IsTrue(typeof(CargoModule).IsSealed, "CargoModule должен быть объявлен как sealed");
                Assert.IsTrue(typeof(AbstractModule).IsAbstract, "AbstractModule должен быть объявлен как abstract");
                passed++;
                Console.WriteLine("✅ [PASS] Test_SealedClassesCheck");
            } catch (TestFailureException ex) {
                failed++;
                Console.WriteLine($"❌ [FAIL] Test_SealedClassesCheck: {ex.Message}");
            }

            Console.WriteLine($"\n Итог: {passed} пройдено, {failed} провалено. Всего: {passed + failed}");
        }
    }

    public class TestFailureException : Exception {
        public TestFailureException(string message) : base(message) { }
    }

    public static class Assert {
        public static void IsTrue(bool condition, string msg) {
            if (!condition) throw new TestFailureException($"[Assert.IsTrue] {msg}");
        }

        public static void IsFalse(bool condition, string msg) {
            if (condition) throw new TestFailureException($"[Assert.IsFalse] {msg}");
        }

        public static void AreEqual<T>(T expected, T actual, string msg) {
            if (!EqualityComparer<T>.Default.Equals(expected, actual))
                throw new TestFailureException($"[Assert.AreEqual] {msg} | Expected: {expected}, Actual: {actual}");
        }
    }

    internal struct Coord {
        public int X { get; }
        public int Y { get; }

        public Coord(int x, int y) {
            X = x;
            Y = y;
        }

        public static Coord operator +(Coord a, Coord b) => new Coord(a.X + b.X, a.Y + b.Y);
        public static Coord operator -(Coord a, Coord b) => new Coord(a.X - b.X, a.Y - b.Y);
        public static Coord operator *(Coord a, int scalar) => new Coord(a.X * scalar, a.Y * scalar);

        public static bool operator ==(Coord a, Coord b) => a.X == b.X && a.Y == b.Y;
        public static bool operator !=(Coord a, Coord b) => !(a == b);

        public override bool Equals(object? obj) => obj is Coord other && this == other;
        public override int GetHashCode() => HashCode.Combine(X, Y);
    }

    internal abstract class AbstractModule {
        public Coord Position { get; }
        public int Fuel { get; protected set; }

        protected AbstractModule(Coord position, int fuel) {
            Position = position;
            Fuel = fuel;
        }

        public abstract void Act();
    }

    internal sealed class ScoutModule : AbstractModule {
        public ScoutModule(Coord position, int fuel) : base(position, fuel) { }

        public override void Act() {
            Console.WriteLine($"ScoutModule at ({Position.X}, {Position.Y}) is scouting...");
        }
    }

    internal sealed class CargoModule : AbstractModule {
        public CargoModule(Coord position, int fuel) : base(position, fuel) { }

        public override void Act() {
            Console.WriteLine($"CargoModule at ({Position.X}, {Position.Y}) is transporting cargo...");
        }
    }

    internal class SimulationEngine {
        public bool TryStep(AbstractModule[][] map, int step, out int processed, ref int fuel) {
            processed = 0;
            if (map == null || map.Length == 0) return false;

            foreach (var row in map) {
                if (row == null) continue;
                foreach (var module in row) {
                    if (module == null) continue;
                    module.Act();
                    processed++;
                }
            }

            if (processed == 0) return false;
            fuel = processed * 10;
            return true;
        }
    }
}
