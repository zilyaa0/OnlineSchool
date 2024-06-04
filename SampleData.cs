﻿using OnlineSchool.Data.Models;

namespace OnlineSchool
{
    public class SampleData
    {
        public static void Initialize(AppDbContext context, IWebHostEnvironment env)
        {
            if (!context.Course.Any())
            {
                context.Course.AddRange(
                    new Course
                    {
                        name = "Веб-разработка",
                        shortDesc = "Вы научитесь создавать сайты и веб-приложения",
                        longDesc = "Веб-разработчик создаёт сайты, сервисы и приложения, которыми мы ежедневно пользуемся. Он разрабатывает интернет-магазины, онлайн-банки, поисковики, карты и почтовые клиенты. Веб-разработчик проектирует внешний вид сайта — фронтенд и программирует серверную часть — бэкенд.",
                        img = "https://lab41.co/wp-content/uploads/2022/09/Creative-Digital-Agency.png",
                        price = 61680,
                        duration = 12,
                        path = "veb.pdf"
                    },
                    new Course
                    {
                        name = "Python-разработка",
                        shortDesc = "Идеальный выбор для создания различных типов программного обеспечения",
                        longDesc = "Python используется много где: от веб-разработки до машинного обучения и научных исследований. Наш курс посвящён созданию бэкенда сайтов и веб-приложений.\nБэкенд — это внутренняя часть программы, которая отвечает за логику работы веб-сервиса. Бэкенд-разработчик на Python пишет код, благодаря которому выполняется основной функционал программы.",
                        img = "https://nextbigtechnology.com/wp-content/uploads/2020/10/Hire-Python-Web-Developers.png",
                        price = 59040,
                        duration = 12,
                        path = "python.pdf"
                    },
                    new Course
                    {
                        name = "Тестирование",
                        shortDesc = "Вы научитесь находить ошибки в работе сайтов и приложений с помощью Java или Python",
                        longDesc = "Инженер по тестированию программного обеспечения (он же тестировщик или QA engineer) проверяет IT-продукты на прочность. Он продумывает, что и где может сломаться, прогнозирует сбои и находит ошибки в приложениях, сайтах и программах, чтобы продукт вышел работоспособным.\r\nИнженер по тестированию должен всеми способами испытать надёжность и удобство сервиса на этапе разработки.",
                        img = "https://avatars.mds.yandex.net/i?id=e6194cb9fd2a7f68720ab58092b5e525ae038c0d-12423090-images-thumbs&n=13",
                        price = 53240,
                        duration = 10,
                        path = "testing.pdf"
                    },
                    new Course
                    {
                        name = "Разработка игр",
                        shortDesc = "Вы освоите игровой движок Unreal Engine и язык C++",
                        longDesc = "Unreal Engine — один из самых востребованных и мощных движков. В основном на нём разрабатывают высокобюджетные ПК игры, в которые играют миллионы пользователей.\nПомимо геймдева, Unreal Engine применяют в образовательных проектах, архитектуре, промышленности и кинематографе. Например, движок использовали при создании спецэффектов и графики в сериалах «Мандалорец» и «Мир Дикого Запада».",
                        img = "https://makeagency.ru/uploads/ckeditor/pictures/1459/content_19197916.jpg",
                        price = 137520,
                        duration = 24,
                        path = "game.pdf"
                    },
                    new Course
                    {
                        name = "Мобильная разработка",
                        shortDesc = "Вы с нуля научитесь создавать приложения для смартфонов",
                        longDesc = "Освоите основной язык для разработки мобильных приложений: Kotlin для Android или Swift для iOS. Познакомитесь с Figma — основным приложением для дизайна интерфейсов.\nБудете создавать видимую часть приложений — верстать экраны, располагать кнопки, изображения. ",
                        img = "https://static.tildacdn.com/tild3364-6166-4238-a261-363338366338/mobile-app-developme.png",
                        price = 81280,
                        duration = 16,
                        path = "mobile.pdf"
                    },
                    new Course
                    {
                        name = "Кибербезопасность",
                        shortDesc = "На курсе вы научитесь искать уязвимости и отражать атаки на серверы",
                        longDesc = "Специалист СИБ (систем информационной безопасности) выстраивает защиту для серверов компаний, чтобы не допустить утечки данных. На курсе вы научитесь искать уязвимости, отражать атаки на серверы и минимизировать последствия вторжений. Освоите профессию, спрос на которую растёт и в России, и в мире.",
                        img = "https://www.trymyschool.com/hs-fs/hubfs/20945462.jpg?width=7736&name=20945462.jpg",
                        price = 30450,
                        duration = 6,
                        path = "safety.pdf"
                    }
                 );
                context.SaveChanges();
            }
        }
    }
}
