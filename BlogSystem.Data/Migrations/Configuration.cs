using System;
using System.Linq;
using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using BlogSystem.Common;
using BlogSystem.Data.Models;

namespace BlogSystem.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        private UserManager<ApplicationUser> userManager;

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            SeedSettings(context);
            SeedRoles(context);
            SeedAdmin(context);
            SeedPosts(context);
            SeedServices(context);
        }

        private void SeedSettings(ApplicationDbContext context)
        {
            if (context.Settings.Any())
                return;

            context.Settings.Add(new Setting { Key = "Title", Value = "Nội Thất" });
            context.Settings.Add(new Setting { Key = "Description", Value = "Nội Thất" });
            context.Settings.Add(new Setting { Key = "Keywords", Value = "Nội Thất" });
            context.Settings.Add(new Setting { Key = "Author", Value = "MND" });
            context.Settings.Add(new Setting { Key = "Author_Email", Value = "ducmanhchy@gmail.com" });
        }

        private void SeedRoles(ApplicationDbContext context)
        {
            context.Roles.AddOrUpdate(
                u => u.Name, 
                new IdentityRole(GlobalConstants.AdministratorRoleName),
                new IdentityRole(GlobalConstants.GuestRoleName)
            );

            context.SaveChanges();
        }

        private void SeedAdmin(ApplicationDbContext context)
        {
            if (context.Users.Any())
                return;

            var admin = new ApplicationUser
            {
                Email = "ducmanhchy@gmail.com",
                UserName = "admin",
                CreatedOn = DateTime.Now,
                UserCreate = "admin"
            };

            userManager.Create(admin, "123123");
            userManager.AddToRole(admin.Id, GlobalConstants.AdministratorRoleName);
        }

        private void SeedPosts(ApplicationDbContext context)
        {
            if (context.Posts.Any())
                return;

            context.Posts.Add(new Post { Title = "Bộ sưu tập OSAKA", ShortContent = "Bộ sưu tập OSAKA", Content = "<div id=\"content\" class=\"blog-wrapper blog-single page-wrapper\">  <article id=\"post-32176\" class=\"post-32176 post type-post status-publish format-standard has-post-thumbnail hentry category-uncategorized-vi tag-mau-thiet-ke-can-ho-vihomes-grand-park life_style-mau-thiet-ke\">  <div class=\"article-inner \">  <div class=\"entry-content single-page\">  <div id=\"row-807221135\" class=\"row\">  <div id=\"col-1366579189\" class=\"col medium-3 small-12 large-3\">  <div class=\"col-inner\">  <div id=\"text-3741289441\" class=\"text\">  <h1>Căn hộ Vinhomes Grand Park 3PN</h1>  <h1>(Quận 9)</h1>  <p>Những gợi &yacute; thiết kế nội thất Dự &aacute;nVinhomes Grand Park (Quận 9) dưới đ&acirc;y sẽ gi&uacute;p &iacute;ch cho bạn.</p>  <p>Vị tr&iacute;:&nbsp;Nguyễn Xiển, Q.9. Tp.HCM</p>  <p>Mặt bằng tổng thể:&nbsp;Căn hộ 3&nbsp;Ph&ograve;ng Ngủ</p>  <p>Phong c&aacute;ch thiết kế:&nbsp;Scandinavian, sự kết hợp giữa những thiết kế tối giản với tone m&agrave;u paste nhẹ nh&agrave;ng.</p>  <p>Thương hiệu nội thất sử dụng: &nbsp;</p>  <p><strong>Nh&agrave; Xinh &nbsp; &nbsp;</strong> &nbsp; &nbsp;</p>  </div>  </div>  </div>  <div id=\"col-775266994\" class=\"col medium-9 small-12 large-9\">  <div class=\"col-inner\">  <div id=\"slider-291668020\" class=\"slider-wrapper relative\">  <div class=\"slider slider-nav-simple slider-nav-large slider-nav-light slider-style-normal is-draggable flickity-enabled slider-lazy-load-active\" tabindex=\"0\" data-flickity-options=\"{              &quot;cellAlign&quot;: &quot;center&quot;,              &quot;imagesLoaded&quot;: true,              &quot;lazyLoad&quot;: 1,              &quot;freeScroll&quot;: false,              &quot;wrapAround&quot;: true,              &quot;autoPlay&quot;: 7000,              &quot;pauseAutoPlayOnHover&quot; : true,              &quot;prevNextButtons&quot;: true,              &quot;contain&quot; : true,              &quot;adaptiveHeight&quot; : true,              &quot;dragThreshold&quot; : 10,              &quot;percentPosition&quot;: true,              &quot;pageDots&quot;: true,              &quot;rightToLeft&quot;: false,              &quot;draggable&quot;: true,              &quot;selectedAttraction&quot;: 0.1,              &quot;parallax&quot; : 0,              &quot;friction&quot;: 0.6        }\">  <div class=\"flickity-viewport\" style=\"height: 617.4px; touch-action: pan-y;\">  <div class=\"flickity-slider\" style=\"left: 0px; transform: translateX(-300%);\">  <div id=\"image_1367740570\" class=\"img has-hover x md-x lg-x y md-y lg-y\" style=\"position: absolute; left: 0%;\" aria-hidden=\"true\">  <div class=\"img-inner dark\"><img class=\"attachment-large size-large lazy-load-active\" src=\"https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-1244x800.jpg\" sizes=\"(max-width: 1020px) 100vw, 1020px\" srcset=\"https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-1244x800.jpg 1244w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-622x400.jpg 622w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-768x494.jpg 768w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-300x193.jpg 300w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-600x386.jpg 600w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9.jpg 1400w\" alt=\"\" width=\"1020\" height=\"656\" data-src=\"https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-1244x800.jpg\" data-srcset=\"https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-1244x800.jpg 1244w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-622x400.jpg 622w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-768x494.jpg 768w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-300x193.jpg 300w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-600x386.jpg 600w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9.jpg 1400w\" /></div>  </div>  <div id=\"image_880492463\" class=\"img has-hover x md-x lg-x y md-y lg-y\" style=\"position: absolute; left: 100%;\" aria-hidden=\"true\">  <div class=\"img-inner dark\"><img class=\"attachment-large size-large lazy-load-active\" src=\"https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-1-1244x800.jpg\" sizes=\"(max-width: 1020px) 100vw, 1020px\" srcset=\"https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-1-1244x800.jpg 1244w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-1-622x400.jpg 622w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-1-768x494.jpg 768w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-1-300x193.jpg 300w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-1-600x386.jpg 600w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-1.jpg 1400w\" alt=\"\" width=\"1020\" height=\"656\" data-src=\"https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-1-1244x800.jpg\" data-srcset=\"https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-1-1244x800.jpg 1244w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-1-622x400.jpg 622w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-1-768x494.jpg 768w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-1-300x193.jpg 300w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-1-600x386.jpg 600w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-1.jpg 1400w\" /></div>  </div>  <div id=\"image_1416372611\" class=\"img has-hover x md-x lg-x y md-y lg-y\" style=\"position: absolute; left: 200%;\" aria-hidden=\"true\">  <div class=\"img-inner dark\"><img class=\"attachment-large size-large lazy-load-active\" src=\"https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-2-1-1244x800.jpg\" sizes=\"(max-width: 1020px) 100vw, 1020px\" srcset=\"https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-2-1-1244x800.jpg 1244w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-2-1-622x400.jpg 622w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-2-1-768x494.jpg 768w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-2-1-300x193.jpg 300w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-2-1-600x386.jpg 600w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-2-1.jpg 1400w\" alt=\"\" width=\"1020\" height=\"656\" data-src=\"https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-2-1-1244x800.jpg\" data-srcset=\"https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-2-1-1244x800.jpg 1244w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-2-1-622x400.jpg 622w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-2-1-768x494.jpg 768w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-2-1-300x193.jpg 300w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-2-1-600x386.jpg 600w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-2-1.jpg 1400w\" /></div>  </div>  <div id=\"image_658259383\" class=\"img has-hover x md-x lg-x y md-y lg-y is-selected\" style=\"position: absolute; left: 300%;\">  <div class=\"img-inner dark\"><img class=\"attachment-large size-large lazy-load-active\" src=\"https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-3-1244x800.jpg\" sizes=\"(max-width: 1020px) 100vw, 1020px\" srcset=\"https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-3-1244x800.jpg 1244w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-3-622x400.jpg 622w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-3-768x494.jpg 768w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-3-300x193.jpg 300w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-3-600x386.jpg 600w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-3.jpg 1400w\" alt=\"\" width=\"1020\" height=\"656\" data-src=\"https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-3-1244x800.jpg\" data-srcset=\"https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-3-1244x800.jpg 1244w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-3-622x400.jpg 622w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-3-768x494.jpg 768w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-3-300x193.jpg 300w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-3-600x386.jpg 600w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-3.jpg 1400w\" /></div>  </div>  <div id=\"image_1275727430\" class=\"img has-hover x md-x lg-x y md-y lg-y\" style=\"position: absolute; left: 400%;\" aria-hidden=\"true\">  <div class=\"img-inner dark\"><img class=\"lazy-load attachment-large size-large\" />\" sizes=\"(max-width: 1020px) 100vw, 1020px\" srcset=\"\" alt=\"\" width=\"1020\" height=\"656\" data-src=\"https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-4-1244x800.jpg\" data-srcset=\"https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-4-1244x800.jpg 1244w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-4-622x400.jpg 622w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-4-768x494.jpg 768w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-4-300x193.jpg 300w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-4-600x386.jpg 600w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-4.jpg 1400w\" /&gt;</div>  </div>  <div id=\"image_960940841\" class=\"img has-hover x md-x lg-x y md-y lg-y\" style=\"position: absolute; left: 500%;\" aria-hidden=\"true\">  <div class=\"img-inner dark\"><img class=\"lazy-load attachment-large size-large\" />\" sizes=\"(max-width: 1020px) 100vw, 1020px\" srcset=\"\" alt=\"\" width=\"1020\" height=\"656\" data-src=\"https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-5-1244x800.jpg\" data-srcset=\"https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-5-1244x800.jpg 1244w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-5-622x400.jpg 622w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-5-768x494.jpg 768w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-5-300x193.jpg 300w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-5-600x386.jpg 600w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-5.jpg 1400w\" /&gt;</div>  </div>  <div id=\"image_1096546252\" class=\"img has-hover x md-x lg-x y md-y lg-y\" style=\"position: absolute; left: 600%;\" aria-hidden=\"true\">  <div class=\"img-inner dark\"><img class=\"lazy-load attachment-large size-large\" />\" sizes=\"(max-width: 1020px) 100vw, 1020px\" srcset=\"\" alt=\"\" width=\"1020\" height=\"656\" data-src=\"https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-6-1244x800.jpg\" data-srcset=\"https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-6-1244x800.jpg 1244w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-6-622x400.jpg 622w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-6-768x494.jpg 768w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-6-300x193.jpg 300w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-6-600x386.jpg 600w, https://nhaxinh.com/wp-content/uploads/2022/01/AKA-uu-dai-cu-dan-nhan-nha-vincom-q9-6.jpg 1400w\" /&gt;</div>  </div>  </div>  </div>  <button class=\"flickity-button flickity-prev-next-button previous\" type=\"button\" aria-label=\"Previous\"></button><button class=\"flickity-button flickity-prev-next-button next\" type=\"button\" aria-label=\"Next\"></button></div>  <div class=\"loading-spin dark large centered\" style=\"display: none;\">&nbsp;</div>  </div>  </div>  </div>  </div>  <div id=\"row-1217821394\" class=\"row\">  <div id=\"col-1807010609\" class=\"col small-12 large-12\">  <div class=\"col-inner\">  <div class=\"lienhe margin-t80\">  <div class=\"container\">  <div class=\"row\">  <div class=\"col-sm-12 col-md-6 pr-0\">  <div class=\"form_lh\">  <div class=\"hotline\">Hotline: 1800 7200</div>  <div class=\"title\">  <h3>Bạn muốn đăng k&yacute; tư vấn thiết kế nội thất?</h3>  <p>Xin vui l&ograve;ng để lại th&ocirc;ng tin của bạn, Nh&agrave; Xinh sẽ li&ecirc;n hệ lại ngay</p>  <p>Bạn cũng c&oacute; thể gọi ngay đến số Hotline 18007200 để được tư vẫn trực tiếp</p>  </div>  <div id=\"wpcf7-f10-p32176-o1\" class=\"wpcf7\" dir=\"ltr\" lang=\"en-US\" role=\"form\">  <div class=\"screen-reader-response\">&nbsp;</div>  <form class=\"wpcf7-form init\" action=\"/can-ho-vinhomes-grand-park/#wpcf7-f10-p32176-o1\" enctype=\"multipart/form-data\" method=\"post\" novalidate=\"novalidate\" data-status=\"init\">  <div style=\"display: none;\"><input name=\"_wpcf7\" type=\"hidden\" value=\"10\" /> <input name=\"_wpcf7_version\" type=\"hidden\" value=\"5.5.2\" /> <input name=\"_wpcf7_locale\" type=\"hidden\" value=\"en_US\" /> <input name=\"_wpcf7_unit_tag\" type=\"hidden\" value=\"wpcf7-f10-p32176-o1\" /> <input name=\"_wpcf7_container_post\" type=\"hidden\" value=\"32176\" /> <input name=\"_wpcf7_posted_data_hash\" type=\"hidden\" value=\"\" /> <input name=\"_wpcf7_recaptcha_response\" type=\"hidden\" value=\"03ANYolqsB11MxML4pYCVXb43Va8jfSr2Tc0tzzDNvWCG_Q9GPmYUWS-zeD_DT5m-k8tu5h7mwtMm3lAH0iUdxbqME3Xg8Nt7VJNWKOpQJcsxzEcmW4r1hk5BD4AiqhpYz7f0qr_8BN3ko9mUo-W5qxqoSc69fr_PYf8mXhDZAIap-w4WpL8y4VDoE8QjjClMGw4Vej1GgzqahSVjmZNUSq-2lhYK8WTx70hTbJfjb2af4O2exrACouBdRVYC4dmOU5fMWZET2PvqwXM75qP11H1K_XHKq-y9VUY3jWqND1J9uLC3iE8ICYgwHRcoGxF9G0pIdQrp23M55Le3vE4y3ILPZ_2eeF1uULPTh98emxH4iqruc72aFnh5qzGz-_3ONnaLyK_H_DbCc56CXevhBAP-f8SjLuGlwlUH9Lw67oVdS-GzP4ViJJ7FrvXMbOwuXJhu1jtHssSNNOEEuZHT9qIsleie9GSDXLKlCKF97urDKvyck-65ceoq-qQDOYpnjuyX-qbx2XOra\" /></div>  <div class=\"row\">  <div class=\"col\"><span class=\"wpcf7-form-control-wrap text-54\"><input class=\"wpcf7-form-control wpcf7-text form-control\" name=\"text-54\" size=\"40\" type=\"text\" value=\"\" placeholder=\"Họ t&ecirc;n\" aria-invalid=\"false\" /></span></div>  <div class=\"col\"><span class=\"wpcf7-form-control-wrap tel-585\"><input class=\"wpcf7-form-control wpcf7-text wpcf7-tel wpcf7-validates-as-tel form-control\" name=\"tel-585\" size=\"40\" type=\"tel\" value=\"\" placeholder=\"+(84) 0123 456\" aria-invalid=\"false\" /></span></div>  </div>  <div class=\"form-group\"><span class=\"wpcf7-form-control-wrap email-638\"><input class=\"wpcf7-form-control wpcf7-text wpcf7-email wpcf7-validates-as-required wpcf7-validates-as-email form-control\" name=\"email-638\" size=\"40\" type=\"email\" value=\"\" placeholder=\"Enter email\" aria-required=\"true\" aria-invalid=\"false\" /></span></div>  <div class=\"form-group\"><span class=\"wpcf7-form-control-wrap textarea-798\"><textarea class=\"wpcf7-form-control wpcf7-textarea wpcf7-validates-as-required form-control\" cols=\"40\" name=\"textarea-798\" rows=\"10\" placeholder=\"Nội dung li&ecirc;n hệ\" aria-required=\"true\" aria-invalid=\"false\"></textarea></span></div>  <div class=\"form-group\">&nbsp;</div>  <div class=\"row\">  <div class=\"col\"><span class=\"wpcf7-form-control-wrap file-4\"><input class=\"wpcf7-form-control wpcf7-file\" accept=\".jpg,.jpeg,.png,.gif,.pdf,.doc,.docx,.ppt,.pptx,.odt,.avi,.ogg,.m4a,.mov,.mp3,.mp4,.mpg,.wav,.wmv\" name=\"file-4\" size=\"40\" type=\"file\" aria-invalid=\"false\" /></span></div>  <div class=\"col text-right\"><input class=\"wpcf7-form-control has-spinner wpcf7-submit btn\" type=\"submit\" value=\"Gửi y&ecirc;u cầu\" /></div>  </div>  <div class=\"wpcf7-response-output\" aria-hidden=\"true\">&nbsp;</div>  </form></div>  </div>  </div>  <div class=\"col-sm-12 col-md-6\"><img class=\"lazy-load img_lienhe\" />\" alt=\"img li&ecirc;n hệ\" data-src=\"/wp-content/uploads/2021/12/nha-xinh-banner-ban-can-lien-he-091221.jpg\" /&gt;</div>  </div>  </div>  </div>  </div>  </div>  </div>  <div id=\"row-2143434111\" class=\"row row-collapse row-full-width\">&nbsp;</div>  <div id=\"row-1087771710\" class=\"row row-collapse row-full-width bg_footer\">  <div id=\"col-898580776\" class=\"col small-12 large-12\">  <div class=\"col-inner text-center\">  <div class=\"message-box relative bg_footer dark\">  <div class=\"message-box-bg-image bg-fill fill\" style=\"background-image: url('https://nhaxinh.com/wp-content/uploads/2021/11/1920x650-2.jpg');\">&nbsp;</div>  <div class=\"message-box-bg-overlay bg-fill fill\">&nbsp;</div>  <div class=\"container relative\">  <div class=\"inner last-reset\">  <div id=\"row-1736879999\" class=\"row row-collapse align-middle align-center\">  <div id=\"col-1675481076\" class=\"col small-12 large-12\">  <div class=\"col-inner\">  <h3>Xem, chạm v&agrave; cảm nhận</h3>  </div>  </div>  <div id=\"col-236011443\" class=\"col medium-2 small-12 large-2\">  <div class=\"col-inner text-center\"><a class=\"button white is-outline lowercase\" href=\"../../he-thong-cua-hang/\" target=\"_self\"> T&igrave;m cửa h&agrave;ng </a></div>  </div>  </div>  </div>  </div>  </div>  </div>  </div>  </div>  </div>  </div>  </article>  </div>", AuthorId = context.Users.FirstOrDefault().Id, isPublish = true, type = "", ParentType = "BST", linkIMG = "", TitleIMG = "", status = 0, CreatedOn = new DateTime(), UserCreate = "", ModifiedOn = null, UserModify = "", IsDeleted = false, DeletedOn = null, UserDelete = "", Desc = "", LinkPost = "", Ord = 0 });
            context.Posts.Add(new Post { Title = "Slide Home", ShortContent = "slide 01", Content = "<div class=\"container custom-container-2\">  <div class=\"row\">  <div class=\"col-xl-7 col-lg-7 col-md-10\">  <div class=\"slider__content slider__content-5\">  <h2 data-animation=\"fadeInUp\" data-delay=\".2s\">Thiết kế độc đ&aacute;o <br />s&aacute;ng tạo.</h2>  <p data-animation=\"fadeInUp\" data-delay=\".4s\">Chỉ c&oacute; thể t&igrave;m thấy ở ch&uacute;ng t&ocirc;i.</p>  <a class=\"os-btn-4 btn bg-light opacity-65\" href=\"#\" data-animation=\"fadeInUp\" data-delay=\".6s\">KH&Aacute;M PH&Aacute; NGAY</a></div>  </div>  </div>  </div>", AuthorId = context.Users.FirstOrDefault().Id, isPublish = true, type = "SL_HOME", ParentType = "HOME", linkIMG = "", TitleIMG = "", status = 0, CreatedOn = new DateTime(), UserCreate = "", ModifiedOn = null, UserModify = "", IsDeleted = false, DeletedOn = null, UserDelete = "", Desc = "", LinkPost = "#", Ord = 1 });
            context.Posts.Add(new Post { Title = "Slide Home", ShortContent = "slide 02", Content = "<div class=\"container\">  <div class=\"row\">  <div class=\"col-xl-12\">  <div class=\"page__title-inner text-center\">  <h1 data-animation=\"fadeInUp\" data-delay=\".2s\">BỘ SƯU TẬP OSAKA</h1>  <div class=\"page__title-breadcrumb\"><nav aria-label=\"breadcrumb\">  <div class=\"breadcrumb justify-content-center\"><a class=\"os-btn-4 btn bg-light opacity-65\" href=\"#\" data-animation=\"fadeInUp\" data-delay=\".6s\">KH&Aacute;M PH&Aacute; NGAY</a></div>  </nav></div>  </div>  </div>  </div>  </div>", AuthorId = context.Users.FirstOrDefault().Id, isPublish = true, type = "SL_HOME", ParentType = "HOME", linkIMG = "", TitleIMG = "", status = 0, CreatedOn = new DateTime(), UserCreate = "", ModifiedOn = null, UserModify = "", IsDeleted = false, DeletedOn = null, UserDelete = "", Desc = "", LinkPost = "#", Ord = 2 });
            context.Posts.Add(new Post { Title = "Banner Home", ShortContent = "Banner Home 01", Content = "<div class=\"banner__item-3 mb-30\">  <div class=\"banner__item-3-image m-img\"><img src=\"https://nhaxinhsaigon.com/source/noi-that/175-mau-noi-that-nha-dep/phong-an-trang-tri-dep-175.jpg\" alt=\"\" /></div>  <div class=\"banner__content-5\">  <h5>FASHION FOR MEN&rsquo;S</h5>  <p>Claritas est etiam processus dynamicus, qui sequitur mutationem consuetudium lectorum.</p>  <a class=\"os-btn-5\" href=\"#\">Xem Th&ecirc;m</a></div>  </div>", AuthorId = context.Users.FirstOrDefault().Id, isPublish = true, type = "BN_HOME", ParentType = "HOME", linkIMG = "", TitleIMG = "", status = 0, CreatedOn = new DateTime(), UserCreate = "", ModifiedOn = null, UserModify = "", IsDeleted = false, DeletedOn = null, UserDelete = "", Desc = "", LinkPost = "", Ord = 0 });
            context.Posts.Add(new Post { Title = "Banner Home", ShortContent = "Banner Home 02", Content = "<div class=\"banner__item-3 mb-30\">  <div class=\"banner__item-3-image m-img\"><img src=\"https://fishcreekexchange.ca/assets/build/img/website/pages/home/Fulcrum%20-%20Graywood%20-%20High%20Resolution-011.png\" alt=\"\" /></div>  <div class=\"banner__content-5\">  <h5>FASHION FOR MEN&rsquo;S</h5>  <p>Claritas est etiam processus dynamicus, qui sequitur mutationem consuetudium lectorum.</p>  <a class=\"os-btn-5\" href=\"shop-3-col.html\">Xem Th&ecirc;m</a></div>  </div>", AuthorId = context.Users.FirstOrDefault().Id, isPublish = true, type = "BN_HOME", ParentType = "HOME", linkIMG = "", TitleIMG = "", status = 0, CreatedOn = new DateTime(), UserCreate = "", ModifiedOn = null, UserModify = "", IsDeleted = false, DeletedOn = null, UserDelete = "", Desc = "", LinkPost = "", Ord = 1 });
            context.Posts.Add(new Post { Title = "Banner Home", ShortContent = "Banner Home 03", Content = "<div class=\"banner__item-3 mb-30\">  <div class=\"banner__item-3-image m-img\"><img src=\"https://hips.hearstapps.com/hmg-prod/images/header-popular-design-ideas-1648567133.jpeg?crop=1.00xw:1.00xh;0,0&amp;resize=1200:*\" alt=\"\" /></div>  <div class=\"banner__content-5\">  <h5>FASHION FOR MEN&rsquo;S</h5>  <p>Claritas est etiam processus dynamicus, qui sequitur mutationem consuetudium lectorum.</p>  <a class=\"os-btn-5\" href=\"#\">Xem Th&ecirc;m</a></div>  </div>", AuthorId = context.Users.FirstOrDefault().Id, isPublish = true, type = "BN_HOME", ParentType = "HOME", linkIMG = "", TitleIMG = "", status = 0, CreatedOn = new DateTime(), UserCreate = "", ModifiedOn = null, UserModify = "", IsDeleted = false, DeletedOn = null, UserDelete = "", Desc = "", LinkPost = "", Ord = 2 });
            context.Posts.Add(new Post { Title = "Popular Home", ShortContent = "Popular Home", Content = "<div class=\"row\">  <div class=\"col-xl-12\">  <div class=\"section__title-wrapper text-center\">  <div class=\"section__title mb-10\">  <h2>Sản phẩm được quan t&acirc;m nhiều nhất</h2>  </div>  </div>  </div>  </div>  <div class=\"row mt-40\">  <div class=\"col-xl-6 col-lg-6\">  <div class=\"row\">  <div class=\"col-lg-12\">  <div class=\"row\">  <div class=\"col-xl-6 col-lg-12 col-md-6\">  <div class=\"product__item mb-40\">  <div class=\"product__wrapper\">  <div class=\"product__thumb\"><a class=\"w-img\" href=\"#\"> <img src=\"http://viecorp.vn/upload/elfinder/b%C3%A0n%20%C4%83n.jpg\" alt=\"product-img\" /> <img class=\"product__thumb-2\" src=\"https://nhaxinh.com/wp-content/uploads/2022/07/mau-phong-khach-nha-xinh-banner-27722.jpg\" alt=\"product-img\" /> </a>  <div class=\"product__action-3 transition-3\"><a class=\"action-btn\" href=\"#\"> Xem Th&ecirc;m</a></div>  <div class=\"product__sale product__sale-3\"><span class=\"new\">mới</span></div>  </div>  <div class=\"product__content product__content-2 p-relative text-center\">  <div class=\"product__content-inner\">  <h4><a href=\"#\">Modern Luxury</a></h4>  </div>  </div>  </div>  </div>  </div>  <div class=\"col-xl-6 col-lg-12 col-md-6\">  <div class=\"product__item mb-40\">  <div class=\"product__wrapper\">  <div class=\"product__thumb\"><a class=\"w-img\" href=\"#\"> <img src=\"http://viecorp.vn/upload/elfinder/kitchen%20design%202022.jpg\" alt=\"product-img\" /> <img class=\"product__thumb-2\" src=\"http://viecorp.vn/upload/elfinder/%C4%91%C6%A1n%20gi%E1%BA%A3n.jpg\" alt=\"product-img\" /> </a>  <div class=\"product__action-3 transition-3\"><a class=\"action-btn\" href=\"#\"> Xem Th&ecirc;m</a></div>  <div class=\"product__sale product__sale-3\"><span class=\"new\">mới</span></div>  </div>  <div class=\"product__content product__content-2 p-relative text-center\">  <div class=\"product__content-inner\">  <h4><a href=\"#\"> M&agrave;u sắc tươi mới</a></h4>  </div>  </div>  </div>  </div>  </div>  </div>  </div>  <div class=\"col-lg-12\">  <div class=\"product__big-image effectThree mb-40\"><a href=\"#\"> <img src=\"https://nhaxinh.com/wp-content/uploads/2022/07/mau-phong-ngu-nx-banner-27722.jpg\" alt=\"\" /> </a></div>  </div>  </div>  </div>  <div class=\"col-lg-6 col-lg-6\">  <div class=\"row\">  <div class=\"col-lg-12\">  <div class=\"product__big-image effectThree mb-40\"><a href=\"#\"> <img src=\"https://nhaxinh.com/wp-content/uploads/2022/07/mau-phong-an-nha-xinh-banner-27722.jpg\" alt=\"\" /> </a></div>  </div>  <div class=\"col-lg-12\">  <div class=\"row\">  <div class=\"col-xl-6 col-lg-12 col-md-6\">  <div class=\"product__item mb-40\">  <div class=\"product__wrapper\">  <div class=\"product__thumb\"><a class=\"w-img\" href=\"#\"> <img src=\"https://noithatxinh.vn/Images/Upload/images/mua-noi-that-o-dau-re-va-dep-1.jpg\" alt=\"product-img\" /> <img class=\"product__thumb-2\" src=\"https://nhaxinhsaigon.com/source/noi-that/175-mau-noi-that-nha-dep/trang-tri-phong-ngu-dep-175.jpg\" alt=\"product-img\" /> </a>  <div class=\"product__action-3 transition-3\"><a class=\"action-btn\" href=\"#\"> Xem Th&ecirc;m</a></div>  </div>  <div class=\"product__content product__content-2 p-relative text-center\">  <div class=\"product__content-inner\">  <h4><a href=\"#\">Phong c&aacute;ch hiện đại</a></h4>  </div>  </div>  </div>  </div>  </div>  <div class=\"col-xl-6 col-lg-12 col-md-6\">  <div class=\"product__item mb-40\">  <div class=\"product__wrapper\">  <div class=\"product__thumb\"><a class=\"w-img\" href=\"#\"> <img src=\"https://nhaxinhsaigon.com/source/noi-that/175-mau-noi-that-nha-dep/phong-ngu-ong-ba-175.jpg\" alt=\"product-img\" /> <img class=\"product__thumb-2\" src=\"https://nhaxinhsaigon.com/source/noi-that/175-mau-noi-that-nha-dep/phong-ngu-doi-175.jpg\" alt=\"product-img\" /> </a>  <div class=\"product__action-3 transition-3\"><a class=\"action-btn\" href=\"#\"> Xem Th&ecirc;m</a></div>  </div>  <div class=\"product__content product__content-2 p-relative text-center\">  <div class=\"product__content-inner\">  <h4><a href=\"#\">Mang lại nhiều cảm hứng</a></h4>  </div>  </div>  </div>  </div>  </div>  </div>  </div>  </div>  </div>  </div>", AuthorId = context.Users.FirstOrDefault().Id, isPublish = true, type = "PL_HOME", ParentType = "HOME", linkIMG = "", TitleIMG = "", status = 0, CreatedOn = new DateTime(), UserCreate = "", ModifiedOn = null, UserModify = "", IsDeleted = false, DeletedOn = null, UserDelete = "", Desc = "", LinkPost = "", Ord = 0 });
            context.Posts.Add(new Post { Title = "Video Home", ShortContent = "Video Home", Content = "<h5 class=\"video__title\">AWESOME VIDEO LIGHTBOX</h5>  <p>Investigationes demonstraverunt lectores legere me lius quod ii legunt saepius.</p>", AuthorId = context.Users.FirstOrDefault().Id, isPublish = true, type = "VD_HOME", ParentType = "HOME", linkIMG = "", TitleIMG = "", status = 0, CreatedOn = new DateTime(), UserCreate = "", ModifiedOn = null, UserModify = "", IsDeleted = false, DeletedOn = null, UserDelete = "", Desc = "", LinkPost = "https://www.youtube.com/watch?v=9ykYqS63Go0", Ord = 0 });
            context.Posts.Add(new Post { Title = "Thiết kế", ShortContent = "thiết kế - img left", Content = "<h3 style=\"font-weight: 600;\">THIẾT KẾ NỘI THẤT</h3>  <h4>Đội ngũ thiết kế lu&ocirc;n sẵn s&agrave;ng</h4>  <p>Qu&yacute; kh&aacute;ch c&oacute; thể gặp đội ngũ tư vấn thiết kế chuy&ecirc;n nghiệp để được hướng dẫn hay tư vấn gi&uacute;p qu&yacute; kh&aacute;ch h&agrave;ng thực hiện trọn vẹn &yacute; th&iacute;ch của m&igrave;nh.</p>  <h4>Khi li&ecirc;n hệ ch&uacute;ng t&ocirc;i, qu&yacute; kh&aacute;ch được:</h4>  <p>Hướng dẫn qu&yacute; kh&aacute;ch trong việc chọn đồ nội thất<br />Tư vấn thiết kế miễn ph&iacute; khi mua đồ nội thất Nh&agrave; Xinh<br />Tư vấn để c&oacute; một kh&ocirc;ng gian sống h&agrave;i h&ograve;a, ấm c&uacute;ng v&agrave; thoải m&aacute;i<br />Gi&uacute;p qu&yacute; kh&aacute;ch thể hiện phong c&aacute;ch của m&igrave;nh qua kh&ocirc;ng gian sống<br />Từ bản vẽ mặt bằng nh&agrave; qu&yacute; kh&aacute;ch, thiết kế Nh&agrave; Xinh thực hiện bản vẽ 3D gi&uacute;p qu&yacute; kh&aacute;ch dễ d&agrave;ng h&igrave;nh dung thực tế.</p>", AuthorId = context.Users.FirstOrDefault().Id, isPublish = true, type = "GT-L-DESIGN", ParentType = "TK", linkIMG = "", TitleIMG = "", status = 0, CreatedOn = new DateTime(), UserCreate = "", ModifiedOn = null, UserModify = "", IsDeleted = false, DeletedOn = null, UserDelete = "", Desc = "", LinkPost = "", Ord = 0 });
            context.Posts.Add(new Post { Title = "Thiết kế", ShortContent = "thiết kế - img right", Content = "<h3 style=\"font-weight: 600;\">THIẾT KẾ NỘI THẤT</h3>  <h4>Đội ngũ thiết kế lu&ocirc;n sẵn s&agrave;ng</h4>  <p>Qu&yacute; kh&aacute;ch c&oacute; thể gặp đội ngũ tư vấn thiết kế chuy&ecirc;n nghiệp để được hướng dẫn hay tư vấn gi&uacute;p qu&yacute; kh&aacute;ch h&agrave;ng thực hiện trọn vẹn &yacute; th&iacute;ch của m&igrave;nh.</p>  <h4>Khi li&ecirc;n hệ ch&uacute;ng t&ocirc;i, qu&yacute; kh&aacute;ch được:</h4>  <p>Hướng dẫn qu&yacute; kh&aacute;ch trong việc chọn đồ nội thất<br />Tư vấn thiết kế miễn ph&iacute; khi mua đồ nội thất<br />Tư vấn để c&oacute; một kh&ocirc;ng gian sống h&agrave;i h&ograve;a, ấm c&uacute;ng v&agrave; thoải m&aacute;i<br />Gi&uacute;p qu&yacute; kh&aacute;ch thể hiện phong c&aacute;ch của m&igrave;nh qua kh&ocirc;ng gian sống<br />Từ bản vẽ mặt bằng nh&agrave; qu&yacute; kh&aacute;ch, thiết kế được thực hiện bản qua vẽ 3D gi&uacute;p qu&yacute; kh&aacute;ch dễ d&agrave;ng h&igrave;nh dung thực tế.</p>", AuthorId = context.Users.FirstOrDefault().Id, isPublish = true, type = "GT-R-DESIGN", ParentType = "TK", linkIMG = "", TitleIMG = "", status = 0, CreatedOn = new DateTime(), UserCreate = "", ModifiedOn = null, UserModify = "", IsDeleted = false, DeletedOn = null, UserDelete = "", Desc = "", LinkPost = "", Ord = 0 });
        }

        private void SeedServices(ApplicationDbContext context)
        {
            if (context.Services.Any())
                return;
            context.Services.Add(new Service { 
                Title = "Giới thiệu doanh nghiệp", 
                ShortContent = string.Empty, 
                Content = "<h3 id=\"mcetoc_1gdi0irs30\" class=\"elementor-heading-title elementor-size-default\" style=\"text-align: left;\"><strong>GIỚI THIỆU VỀ NỘI THẤT BUILONG</strong></h3>\r\n<p><strong>Nội thất BuiLong</strong> &ndash; Thương hiệu ti&ecirc;n phong đưa quy tr&igrave;nh nh&agrave; di động về Việt Nam, được th&agrave;nh lập từ năm 2020, Trụ sở Showroom quy m&ocirc; hơn 1000m2 ở TDP Tử Ni&ecirc;m, Thị Trấn Phong Sơn, Huyện Cẩm Thủy, Tỉnh Thanh H&oacute;a, Việt Nam.</p>\r\n<h3 id=\"mcetoc_1gdi0irs31\" class=\"elementor-heading-title elementor-size-large\"><strong>TẦM NH&Igrave;N, SỨ MỆNH, GI&Aacute; TRỊ CỐT L&Otilde;I</strong></h3>\r\n<p><strong>Tầm nh&igrave;n:</strong> Trở th&agrave;nh đơn vị h&agrave;ng đầu với những giải ph&aacute;p tổng thể từ thiết kế, thi c&ocirc;ng, quản l&yacute; c&aacute;c c&ocirc;ng tr&igrave;nh biệt thự cao cấp uy t&iacute;n tr&ecirc;n cả nước. Định hướng của BuiLong trong tương lai l&agrave; g&oacute;p phần thay đổi t&iacute;ch cực to&agrave;n bộ xu hướng nội thất Việt v&agrave; mang phong c&aacute;ch c&aacute; nh&acirc;n h&oacute;a kh&aacute;c biệt dẫn đầu đến gần hơn với tất cả kh&aacute;ch h&agrave;ng.</p>\r\n<p><strong>Sứ mệnh: </strong>Tiếp tục ph&aacute;t huy thế mạnh v&agrave; gi&aacute; trị cốt l&otilde;i để tạo n&ecirc;n sự đồng bộ h&oacute;a cao nhất cho c&aacute;c c&ocirc;ng tr&igrave;nh cao cấp, đưa nghệ thuật v&agrave; c&aacute;i đẹp đến với sự ph&aacute;t triển chung của x&atilde; hội.</p>\r\n<p><strong>Gi&aacute; trị cốt l&otilde;i: </strong>BuiLong lu&ocirc;n lấy con người l&agrave;m trung t&acirc;m để kiến tạo những sản phẩm kh&aacute;c biệt v&agrave; chất lượng ho&agrave;n hảo nhất, bằng đạo đức l&agrave;m nghề được đặt l&ecirc;n h&agrave;ng đầu để phục vụ tốt nhất đến qu&yacute; kh&aacute;ch h&agrave;ng.</p>\r\n<h3 id=\"mcetoc_1gdi0irs32\" class=\"elementor-heading-title elementor-size-default\"><strong>TẬP TRUNG DUY NHẤT MỘT PH&Acirc;N KH&Uacute;C - NỘI THẤT CAO CẤP</strong></h3>\r\n<p>Định hướng con đường ph&aacute;t triển kh&aacute;c biệt hẳn với c&aacute;c đơn vị c&ugrave;ng lĩnh vực, Đồng Gia đến với kh&aacute;ch h&agrave;ng với tư c&aacute;ch tổng thầu thiết kế &ndash; thi c&ocirc;ng, cung cấp giải ph&aacute;p&nbsp;tổng thể từ kh&acirc;u cải tạo kiến tr&uacute;c v&agrave; thi c&ocirc;ng ho&agrave;n thiện.</p>\r\n<p>Ch&uacute;ng t&ocirc;i tập trung ph&acirc;n kh&uacute;c cao cấp: Biệt thự tại Vingroup; Penthouse; SkyVilla;&hellip; thể hiện đẳng cấp độc t&ocirc;n của đơn vị thiết kế thi c&ocirc;ng nội, nh&agrave; ở di động ti&ecirc;n phong&nbsp;từ xu hướng cho đến phong c&aacute;ch, sản phẩm mẫu,..</p>\r\n<h3 id=\"mcetoc_1gdi0irs33\" class=\"elementor-heading-title elementor-size-default\"><strong>SẢN PHẨM NỘI THẤT ĐỘC NHẤT &ndash; MADE IN VIETNAM</strong></h3>\r\n<p>Được biết đến với tư c&aacute;ch l&agrave; đơn vị dẫn đầu với những sản phẩm nội thất độc quyền s&aacute;ng tạo, được đăng k&yacute; bản quyền v&agrave; thể hiện sự tự h&agrave;o d&agrave;nh cho những cống hiến v&igrave;&nbsp;sự th&agrave;nh c&ocirc;ng của sản phẩm Made In Việt Nam. Trải qua qu&aacute; tr&igrave;nh nghi&ecirc;n cứu ph&aacute;t triển, kh&eacute;p k&iacute;n trong quy tr&igrave;nh thiết kế thi c&ocirc;ng ho&agrave;n thiện với nguồn nguy&ecirc;n liệu cao cấp, đạt ti&ecirc;u chuẩn Ch&acirc;u &Acirc;u, BuiLong đ&atilde; tạo n&ecirc;n những sản phẩm nghệ thuật mang gi&aacute; trị cao v&agrave; thể hiện đẳng cấp ri&ecirc;ng của gia chủ.</p>\r\n<h3 id=\"mcetoc_1gdi10t0d7\" class=\"elementor-heading-title elementor-size-default\"><strong>SHOWROOM NỘI THẤT DUY NHẤT&nbsp;-&nbsp;NHỮNG TRẢI NGHIỆM HO&Agrave;N TO&Agrave;N MỚI​</strong></h3>\r\n<p>Trải qua thời gian d&agrave;i ph&aacute;t triển vững mạnh, năm 2022 ch&iacute;nh thức trụ sở Showroom của Nội Thất B&ugrave;i Long chuyển về vị tr&iacute; trung t&acirc;m H&agrave; Nội với diện t&iacute;ch hơn 1000m2 v&agrave;</p>\r\n<p>trở th&agrave;nh địa điểm thưởng l&atilde;m c&aacute;c t&aacute;c phẩm nội thất gi&agrave;u t&iacute;nh nghệ thuật, tinh hoa nhất.</p>\r\n<h3 id=\"mcetoc_1gdi0irs36\" class=\"elementor-heading-title elementor-size-default\"><strong>NH&Agrave; M&Aacute;Y SẢN XUẤT QUY M&Ocirc; DUY NHẤT</strong></h3>\r\n<p>B&ugrave;i Long ho&agrave;n thiện nh&agrave; m&aacute;y sản xuất chuy&ecirc;n nghiệp l&ecirc;n đến hơn 4000m2 với việc nhập khẩu m&aacute;y m&oacute;c thiết bị hiện đại v&agrave; d&acirc;y truyền đồng bộ khoa học b&ecirc;n cạnh những&nbsp;si&ecirc;u phẩm Handmade độc bản cao cấp từ c&aacute;c loại gỗ tự nhi&ecirc;n.</p>\r\n<p>Với gần 100 nghệ nh&acirc;n tay nghề cao, d&agrave;y dặn kinh nghiệm, t&acirc;m huyết, y&ecirc;u nghề v&agrave; chỉn chu c&aacute;c c&ocirc;ng đoạn để tạo ra những sản phẩm độc bản tỉ mỉ nhất; đặc biệt nh&agrave; m&aacute;y&nbsp;sử dụng dầu lau th&acirc;n thiện với m&ocirc;i trường, bảo vệ sức khỏe v&agrave; tạo n&ecirc;n một m&ocirc;i trường l&agrave;m việc hiện đại, văn minh nhất.</p>\r\n<h3><strong>TR&Aacute;CH NHIỆM VỚI CỘNG ĐỒNG</strong></h3>\r\n<p>Ch&uacute;ng t&ocirc;i lu&ocirc;n đặt tr&aacute;ch nhiệm với cộng đồng song song với hoạt động trao tặng gi&aacute; trị v&agrave; kh&ocirc;ng gian sống cho qu&yacute; kh&aacute;ch h&agrave;ng, cụ thể th&ocirc;ng qua những hoạt động:</p>\r\n<p><strong>Bảo vệ m&ocirc;i trường:&nbsp;</strong>Sử dụng nguồn gỗ nhập khẩu t&aacute;i sinh tự nhi&ecirc;n duy tr&igrave; nguồn t&agrave;i nguy&ecirc;n; Giải ph&aacute;p kiến tr&uacute;c XANH với việc sử dụng hiệu quả năng lượng, t&agrave;i nguy&ecirc;n, &aacute;nh s&aacute;ng&hellip; bảo vệ sức&nbsp;khỏe con người v&agrave; giảm thiếu tối đa chất thải, &ocirc; nhiễm m&ocirc;i trường.</p>", 
                AuthorId = null, 
                isPublish = true, 
                type = "TT", 
                ParentType = "SV", 
                linkIMG = "", 
                TitleIMG = "", 
                status = 0, 
                CreatedOn = new DateTime(), 
                UserCreate = "", 
                ModifiedOn = null, 
                UserModify = "", 
                IsDeleted = false, 
                DeletedOn = null, 
                UserDelete = "", 
                Desc = "", 
                LinkPost = "", 
                Ord = 1 });
            context.Services.Add(new Service
            {
                Title = "Hợp tác",
                ShortContent = string.Empty,
                Content = "Hợp tác",
                AuthorId = null,
                isPublish = true,
                type = "TT",
                ParentType = "SV",
                linkIMG = "",
                TitleIMG = "",
                status = 0,
                CreatedOn = new DateTime(),
                UserCreate = "",
                ModifiedOn = null,
                UserModify = "",
                IsDeleted = false,
                DeletedOn = null,
                UserDelete = "",
                Desc = "",
                LinkPost = "#",
                Ord = 2
            });
            context.Services.Add(new Service
            {
                Title = "Tin tức",
                ShortContent = string.Empty,
                Content = "Tin tức",
                AuthorId = null,
                isPublish = true,
                type = "TT",
                ParentType = "SV",
                linkIMG = "",
                TitleIMG = "",
                status = 0,
                CreatedOn = new DateTime(),
                UserCreate = "",
                ModifiedOn = null,
                UserModify = "",
                IsDeleted = false,
                DeletedOn = null,
                UserDelete = "",
                Desc = "",
                LinkPost = "#",
                Ord = 4
            });
            context.Services.Add(new Service
            {
                Title = "Tuyển dụng",
                ShortContent = string.Empty,
                Content = "Tuyển dụng",
                AuthorId = null,
                isPublish = true,
                type = "TT",
                ParentType = "SV",
                linkIMG = "",
                TitleIMG = "",
                status = 0,
                CreatedOn = new DateTime(),
                UserCreate = "",
                ModifiedOn = null,
                UserModify = "",
                IsDeleted = false,
                DeletedOn = null,
                UserDelete = "",
                Desc = "",
                LinkPost = "#",
                Ord = 5
            });

            context.Services.Add(new Service
            {
                Title = "Hướng dẫn mua hàng",
                ShortContent = string.Empty,
                Content = "Hướng dẫn mua hàng",
                AuthorId = null,
                isPublish = true,
                type = "DVKH",
                ParentType = "SV",
                linkIMG = "",
                TitleIMG = "",
                status = 0,
                CreatedOn = new DateTime(),
                UserCreate = "",
                ModifiedOn = null,
                UserModify = "",
                IsDeleted = false,
                DeletedOn = null,
                UserDelete = "",
                Desc = "",
                LinkPost = "#",
                Ord = 1
            });
            context.Services.Add(new Service
            {
                Title = "Quy định vận chuyển",
                ShortContent = string.Empty,
                Content = "Quy định vận chuyển",
                AuthorId = null,
                isPublish = true,
                type = "DVKH",
                ParentType = "SV",
                linkIMG = "",
                TitleIMG = "",
                status = 0,
                CreatedOn = new DateTime(),
                UserCreate = "",
                ModifiedOn = null,
                UserModify = "",
                IsDeleted = false,
                DeletedOn = null,
                UserDelete = "",
                Desc = "",
                LinkPost = "#",
                Ord = 2
            });
            context.Services.Add(new Service
            {
                Title = "Bảo hành/Bảo trì",
                ShortContent = string.Empty,
                Content = "Bảo hành/Bảo trì",
                AuthorId = null,
                isPublish = true,
                type = "DVKH",
                ParentType = "SV",
                linkIMG = "",
                TitleIMG = "",
                status = 0,
                CreatedOn = new DateTime(),
                UserCreate = "",
                ModifiedOn = null,
                UserModify = "",
                IsDeleted = false,
                DeletedOn = null,
                UserDelete = "",
                Desc = "",
                LinkPost = "#",
                Ord = 3
            });
            context.Services.Add(new Service
            {
                Title = "Chính sách bảo mật",
                ShortContent = string.Empty,
                Content = "Chính sách bảo mật",
                AuthorId = null,
                isPublish = true,
                type = "DVKH",
                ParentType = "SV",
                linkIMG = "",
                TitleIMG = "",
                status = 0,
                CreatedOn = new DateTime(),
                UserCreate = "",
                ModifiedOn = null,
                UserModify = "",
                IsDeleted = false,
                DeletedOn = null,
                UserDelete = "",
                Desc = "",
                LinkPost = "#",
                Ord = 4
            });
            context.Services.Add(new Service
            {
                Title = "Chính sách bảo hành",
                ShortContent = string.Empty,
                Content = "Chính sách bảo hành",
                AuthorId = null,
                isPublish = true,
                type = "DVKH",
                ParentType = "SV",
                linkIMG = "",
                TitleIMG = "",
                status = 0,
                CreatedOn = new DateTime(),
                UserCreate = "",
                ModifiedOn = null,
                UserModify = "",
                IsDeleted = false,
                DeletedOn = null,
                UserDelete = "",
                Desc = "",
                LinkPost = "#",
                Ord = 1
            });
        }
    }
}