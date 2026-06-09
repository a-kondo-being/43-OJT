using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcchimuitehoiQuest
{
    public partial class QuestForm : Form
    {
        // StageManager を利用
        private StageManager stageManager = new StageManager();

        // ユーザーが指定した絶対パス（必要ならフォールバックで使用）
        private static readonly string GolemAbsolutePath = @"..\Picture\ゴーレムダウンロード.png";
        private static readonly string MaouAbsolutePath = @"..\Picture\魔王ダウンロード.png";

        public QuestForm()
        {
            InitializeComponent();
        }

        // ファイルから安全に読み込み（ファイルロックを残さない）
        private Image TryLoadImage(string path)
        {
            try
            {
                if (string.IsNullOrEmpty(path)) return null;
                if (!File.Exists(path)) return null;
                using (var img = Image.FromFile(path))
                {
                    return new Bitmap(img);
                }
            }
            catch
            {
                return null;
            }
        }

        // Picture フォルダや候補パスを試して画像を取得
        private Image LoadImageForEnemy(Enemy enemy)
        {
            if (enemy == null) return pictureslime?.BackgroundImage;

            string[] candidates;
            if (enemy.Name.Contains("スライム"))
            {
                candidates = new[] { "スライム左.png", "スライム.png", "スライムダウンロード (1).pngooo[[[.png", "slime_front.png" };
            }
            else if (enemy.Name.Contains("ゴーレム"))
            {
                candidates = new[] { "ゴーレムダウンロード.png", "ゴーレム.png", "golem.png", "golem_front.png" };
            }
            else if (enemy.Name.Contains("魔王") || enemy.Name.Contains("デーモン") || enemy.Name.Contains("Demon"))
            {
                candidates = new[] { "魔王ダウンロード.png", "魔王.png", "maou.png", "demonking.png" };
            }
            else
            {
                candidates = new string[0];
            }

            // 実行ファイルと同階層の Picture、またはプロジェクト直下の Picture を候補にする
            var baseDirs = new List<string>
            {
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Picture"),
                Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "AcchimuitehoiQuest", "Picture")),
                Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Picture")),
            };

            // ユーザー指定絶対ディレクトリも追加
            baseDirs.Add(Path.GetDirectoryName(GolemAbsolutePath));
            baseDirs.Add(Path.GetDirectoryName(MaouAbsolutePath));

            foreach (var dir in baseDirs.Where(d => !string.IsNullOrEmpty(d)).Distinct())
            {
                foreach (var file in candidates)
                {
                    var path = Path.Combine(dir, file);
                    var img = TryLoadImage(path);
                    if (img != null) return img;
                }
            }

            // 絶対パスの直接試行（ゴーレム/魔王のための既定パス）
            if (enemy.Name.Contains("ゴーレム"))
            {
                var img = TryLoadImage(GolemAbsolutePath);
                if (img != null) return img;
            }
            if (enemy.Name.Contains("魔王"))
            {
                var img = TryLoadImage(MaouAbsolutePath);
                if (img != null) return img;
            }

            // リソースから探す（Resource 名がある場合）
            try
            {
                var res = Properties.Resources.ResourceManager.GetObject("Slime") as Image;
                if (enemy.Name.Contains("スライム") && res != null) return res;
                res = Properties.Resources.ResourceManager.GetObject("Golem") as Image;
                if (enemy.Name.Contains("ゴーレム") && res != null) return res;
                res = Properties.Resources.ResourceManager.GetObject("Maou") as Image;
                if (enemy.Name.Contains("魔王") && res != null) return res;
            }
            catch
            {
                // ignore
            }

            // 最終フォールバック：既存の pictureslime の画像
            return pictureslime?.BackgroundImage;
        }

        // Enemy を元に表示を更新
        private async Task DisplayCurrentEnemy()
        {
            var enemy = stageManager.CurrentEnemy;
            if (enemy == null)
            {
                labelslime.Text = "";
                return;
            }
            string hintText = "";

            // セリフを Enemy.Name に合わせて生成（必要ならステージごとにカスタマイズ）
            if (enemy.Name.Contains("スライム"))
            {

                if (enemy.TargetDirection == 0) hintText = "スライム：お空ってきれいだな～";
                else if (enemy.TargetDirection == 1) hintText = "スライム：じめじめした地面が好きなんだよね～";
                else if (enemy.TargetDirection == 2) hintText = "スライム：あっちから風が吹いてくるな～";
                else if (enemy.TargetDirection == 3) hintText = "スライム：なんだか向こうが気になるな～";
                labelslime.Text = "！";
                await Task.Delay(1500);

                labelslime.Text = "あいつはスライムだ。\n中々やるぞ、気をつけろ！";
            }
            else if (enemy.Name.Contains("ゴーレム"))
            {

                if (enemy.TargetDirection == 0) hintText = "ゴーレム：小石落下ヲ確認";
                else if (enemy.TargetDirection == 1) hintText = "ゴーレム：足元ニ振動アリ";
                else if (enemy.TargetDirection == 2) hintText = "ゴーレム：異常な反応検知";
                else if (enemy.TargetDirection == 3) hintText = "ゴーレム：重量物ノ気配";
                labelslime.Text = "！";
                await Task.Delay(1500);

                labelslime.Text = "あいつはゴーレムだ。\n硬いぞ、隙をつけ！";
            }
            else if (enemy.Name.Contains("魔王"))
            {
                Questpanel2.BackgroundImage = TryLoadImage(@"..\..\Picture\魔王背景1327×829.png");
                if (enemy.TargetDirection == 0) hintText = "魔王：フハハハ！天すら我が力に震えておる！";
                else if (enemy.TargetDirection == 1) hintText = "魔王：深淵の闇が我を呼んでいるぞ…";
                else if (enemy.TargetDirection == 2) hintText = "魔王：漂う魔力、実に心地よい";
                else if (enemy.TargetDirection == 3) hintText = "魔王：空間が歪んでおるな…";
                labelslime.Text = "！";
                await Task.Delay(1500);

                labelslime.Text = "あれが魔王だ！\n力を合わせて倒せ！";
            }
            else
            {
                labelslime.Text = $"あいつは{enemy.Name}だ！";
            }

            await Task.Delay(3000);
            labelslime.Text = hintText;

            // 画像を読み込んで設定
            var img = LoadImageForEnemy(enemy);
            if (img != null)
            {
                pictureslime.BackgroundImage = img;
                pictureslime.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        private async void QuestForm_Shown(object sender, EventArgs e)
        {
            // --- 【1枚目】の処理開始 ---
            Questpanel1.Visible = true;
            Questpanel2.Visible = false;

            labelencount.Text = "村人：助けてくれ！";
            await Task.Delay(2000);

            labelencount.Text = "村人：魔王に攻撃をされた。\n魔王を倒してくれ！";
            await Task.Delay(3000);

            // --- 【2枚目】へ切り替え ---
            Questpanel1.Visible = false;
            Questpanel2.Visible = true;



            // ここで「敵データを作成」して、画像だけを先に表示する
            stageManager.SetupNextStage();                             // CurrentEnemy をセット
            var preImage = LoadImageForEnemy(stageManager.CurrentEnemy);
            if (preImage != null)
            {
                pictureslime.BackgroundImage = preImage;
                pictureslime.BackgroundImageLayout = ImageLayout.Stretch;
            }

            // 勇者のリアクション（ラベルはまだ "！" のまま）
            labelslime.Text = "！";


            // その後、セリフ（と必要なら画像）を正式に表示する
            DisplayCurrentEnemy();

            // 例：次の敵へ進めたい場合は再び SetupNextStage() を呼ぶ
            // stageManager.SetupNextStage();
            // DisplayCurrentEnemy();
            // await Task.Delay(3000);

            // --- この後、バトルに移行するための処理を書く ---
        }

    }
}

