using Baidu.Aip.Face;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_baiduFace
{
    class Program
    {
        static void Main(string[] args)
        {
            // 设置APPID/AK/SK
            var APP_ID = "10555521";
            var API_KEY = "VUp0COuHanI6EqIHI3Nzqewu";
            var SECRET_KEY = "RpTATm79uRuC4ehvIjGC6HVHoPUNIz7r ";

            var client = new Face(API_KEY, SECRET_KEY);
            //人脸检测
            //DetectDemo(client);
            //人脸对比
            //MatchDemo(client);
            //注册用户
            //UserAddDemo(client);
            //查询用户
            //UserGetDemo(client);
            //人脸认证
            VerifyDemo(client);
        }

        public static void DetectDemo(Face client)
        {
            var image = File.ReadAllBytes("timg.jpg");
            // 调用人脸检测，可能会抛出网络等异常，请使用try/catch捕获
            var result = client.Detect(image);
            Console.WriteLine(result);
            // 如果有可选参数
            var options = new Dictionary<string, object>{
                {"max_face_num", 2},
                {"face_fields", "age"}
            };
            // 带参数调用人脸检测
            result = client.Detect(image, options);
            Console.WriteLine(result);
        }

        public static void MatchDemo(Face client)
        {
            var images = new[]
            {
                File.ReadAllBytes("timg.jpg"),
                File.ReadAllBytes("timg.jpg")
            };
            // 调用人脸比对，可能会抛出网络等异常，请使用try/catch捕获
            var result = client.Match(images);
            Console.WriteLine(result);
            // 如果有可选参数
            var options = new Dictionary<string, object>{
                {"ext_fields", "qualities"},
                {"image_liveness", ",faceliveness"},
                {"types", "7,13"}
            };
            // 带参数调用人脸比对
            result = client.Match(images, options);
            Console.WriteLine(result);
        }

        public static void UserAddDemo(Face client)
        {
            var uid = "user1";

            var userInfo = "user's info";

            var groupId = "group1,group2";

            var image = File.ReadAllBytes("timg.jpg");
            // 调用人脸注册，可能会抛出网络等异常，请使用try/catch捕获
            var result = client.UserAdd(uid, userInfo, groupId, image);
            Console.WriteLine(result);
            // 如果有可选参数
            var options = new Dictionary<string, object>{
                {"action_type", "replace"}
            };
            // 带参数调用人脸注册
            result = client.UserAdd(uid, userInfo, groupId, image, options);
            Console.WriteLine(result);
        }

        public static void UserGetDemo(Face client)
        {
            var uid = "user1";

            // 调用用户信息查询，可能会抛出网络等异常，请使用try/catch捕获
            var result = client.UserGet(uid);
            Console.WriteLine(result);
            // 如果有可选参数
            var options = new Dictionary<string, object>{
                {"group_id", "group1"}
            };
            // 带参数调用用户信息查询
            result = client.UserGet(uid, options);
            Console.WriteLine(result);
        }

        public static void VerifyDemo(Face client)
        {
            var uid = "user1";

            var groupId = "group1,group2";

            var image = File.ReadAllBytes("timg.jpg");
            // 调用人脸认证，可能会抛出网络等异常，请使用try/catch捕获
            var result = client.Verify(uid, groupId, image);
            Console.WriteLine(result);
            // 如果有可选参数
            var options = new Dictionary<string, object>{
                {"top_num", 3},
                {"ext_fields", "faceliveness"}
            };
            // 带参数调用人脸认证
            result = client.Verify(uid, groupId, image, options);
            Console.WriteLine(result);
        }
    }
}
