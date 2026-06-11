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
    public partial class QuestForm : FixedSizeForm
    {
        // StageManager を利用
        private StageManager stageManager = new StageManager();
        private BattleManager battleManager;

        // ユーザーが指定した絶対パス（必要ならフォールバックで使用）
        private static readonly string GolemAbsolutePath = @"..\Picture\ゴーレムダウンロード.png";
        private static readonly string MaouAbsolutePath = @"..\Picture\魔王ダウンロード.png";

        public QuestForm()
        {
            InitializeComponent();
            // 任意のクライアントサイズで固定（Designer の ClientSize を上書き）
            SetFixedClientSize(new Size(1374, 769));
            // Reduce flicker by enabling double buffering and optimized painting on the form and key panels
            this.SetStyle(System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer | System.Windows.Forms.ControlStyles.AllPaintingInWmPaint | System.Windows.Forms.ControlStyles.UserPaint, true);
            this.UpdateStyles();
            try { typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(this, true, null); } catch { }
            if (Questpanel1 != null) { try { Questpanel1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(Questpanel1, true, null); } catch { } }
            if (Questpanel2 != null) { try { Questpanel2.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(Questpanel2, true, null); } catch { } }
        }
        // =========================================================
        // ★新規追加：敵が出現した「瞬間」に背景を切り替える処理
        // =========================================================
        private async Task ChangeBackgroundImage(Enemy enemy)
        {
            if (enemy == null) return;

            if (enemy.Name.Contains("魔王"))
            {
                // 魔王用の背景に一瞬で切り替える（非同期で読み込み）
                var img = await TryLoadImageAsync(@"..\..\Picture\魔王背景1327×829.png");
                if (img != null)
                {
                    Questpanel2.BackgroundImage = img;
                }
            }
            else
            {
                // スライムやゴーレムの場合は、通常の背景に戻す（必要に応じて設定）
                // Questpanel2.BackgroundImage = TryLoadImage(@"..\..\Picture\通常背景.png"); 
                // または Properties.Resources.通常背景画像名;
            }
        }

        // イントロ（QuestPanel1 -> QuestPanel2）の表示を一度だけ行うためのフラグ
        private bool introShown = false;

        // Questパネルの順次表示（QuestPanel1 を表示してから QuestPanel2 を表示）
        private async Task ShowIntroSequenceAsync()
        {
            if (introShown) return;
            introShown = true;

            // 1枚目を表示
            Questpanel1.Visible = true;
            Questpanel2.Visible = false;
            labelencount.Text = "村人：助けてくれ！";
            await Task.Delay(2000);

            labelencount.Text = "村人：魔王に攻撃をされた。\n魔王を倒してくれ！";
            await Task.Delay(3000);

            // 2枚目へ切替
            Questpanel1.Visible = false;
            Questpanel2.Visible = true;
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

        // 非同期版：UI スレッドをブロックしないようにディスク I/O はバックグラウンドで行う
        private Task<Image> TryLoadImageAsync(string path)
        {
            return Task.Run(() => TryLoadImage(path));
        }

        // Picture フォルダや候補パスを試して画像を取得
        private Image LoadImageForEnemy(Enemy enemy)
        {
            if (enemy == null) return pictureslime?.BackgroundImage;

            string[] candidates;
            if (enemy.Name.Contains("スライム"))
            {
                candidates = new[] { "スライム左.png", "スライム.png", "スライムダウンロード (1).png", "slime_front.png" };
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

        // 非同期版：LoadImageForEnemy のディスクアクセス部分をバックグラウンドで行い、UI をブロックしない
        private async Task<Image> LoadImageForEnemyAsync(Enemy enemy)
        {
            if (enemy == null) return pictureslime?.BackgroundImage;

            // Run the synchronous loader in a background thread to avoid UI freezes
            return await Task.Run(() => LoadImageForEnemy(enemy));
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
                await Task.Delay(3000);
                labelslime.Text = hintText;
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
                await Task.Delay(3000);
                labelslime.Text = hintText;
            }
            else if (enemy.Name.Contains("魔王"))
            {
                if (enemy.TargetDirection == 0) hintText = "魔王：フハハハ！天すら我が力に震えておる！";
                else if (enemy.TargetDirection == 1) hintText = "魔王：深淵の闇が我を呼んでいるぞ…";
                else if (enemy.TargetDirection == 2) hintText = "魔王：漂う魔力、実に心地よい";
                else if (enemy.TargetDirection == 3) hintText = "魔王：空間が歪んでおるな…";
                labelslime.Text = "！";
                await Task.Delay(1500);

                labelslime.Text = "あれが魔王だ！\n力を合わせて倒せ！";
                await Task.Delay(3000);
                labelslime.Text = hintText;
            }
            else
            {
                labelslime.Text = $"あいつは{enemy.Name}だ！";
            }



            // 画像を読み込んで設定（非同期でディスク I/O を行い UI をブロックしない）
            var img = await LoadImageForEnemyAsync(enemy);
            if (img != null)
            {
                pictureslime.BackgroundImage = img;
                pictureslime.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        private async void QuestForm_Shown(object sender, EventArgs e)
        {
            // フォーム表示時にイントロの演出のみ行う（StartNewGame が実行される場合は
            // 既に ShowIntroSequenceAsync が呼ばれるので二重表示を防ぐ）
            await ShowIntroSequenceAsync();
        }

        // ゲーム開始処理：TitleForm から呼び出す
        // ゲーム開始処理：TitleForm から呼び出す
        public async Task StartNewGame()
        {
            // 初期化
            stageManager = new StageManager();
            battleManager = new BattleManager();

            // イントロ表示（QuestPanel1 -> QuestPanel2）
            await ShowIntroSequenceAsync();

            // --- 最初の敵をセット ---
            stageManager.SetupNextStage(); // CurrentEnemy をセット
            battleManager.SetupEnemy(stageManager.CurrentEnemy);

            var preImage = await LoadImageForEnemyAsync(stageManager.CurrentEnemy);
            if (preImage != null)
            {
                pictureslime.BackgroundImage = preImage;
                pictureslime.BackgroundImageLayout = ImageLayout.Stretch;
            }

            // =========================================================
            // ★追加：最初の敵が出現した「瞬間」に背景も切り替える！
            // =========================================================
            await ChangeBackgroundImage(stageManager.CurrentEnemy);

            labelslime.Text = "！";
            await Task.Delay(500);
            await DisplayCurrentEnemy();
            await Task.Delay(3000);

            // ステージループ：各ステージで BattleForm をモーダル表示
            while (true)
            {
                using (var battleForm = new BattleForm(battleManager, stageManager))
                {
                    // QuestForm を隠してバトル画面をモーダル表示
                    this.Hide();
                    battleForm.ShowDialog(this);
                    this.Show();
                }

                // バトルの結果判定
                if (battleManager.PlayerHP <= 0)
                {
                    // プレイヤー敗北：GameOver を表示
                    var goForm = new GameOverForm();
                    // 不要な画面が見えないように QuestForm を隠す
                    this.Hide();
                    goForm.ShowDialog(this);

                    // ゲーム終了後はアプリケーションを終了する
                    Application.Exit();
                    break;
                }

                // 敵を倒した場合
                if (battleManager.CurrentEnemy != null && battleManager.CurrentEnemy.HP <= 0)
                {
                    // 最終ステージ（3）をクリアしていたらリザルト（勝利）へ
                    if (stageManager.CurrentStageNumber >= 3)
                    {
                        var result = new ResultForm();
                        // 不要な画面が見えないように QuestForm を隠す
                        this.Hide();
                        result.SetStatus("CLEAR");
                        result.ShowDialog(this);

                        // ゲーム終了後はアプリケーションを終了する
                        Application.Exit();
                        break;
                    }

                    // そうでなければ次のステージへ進める
                    stageManager.SetupNextStage();
                    battleManager.SetupEnemy(stageManager.CurrentEnemy);

                    var img = await LoadImageForEnemyAsync(stageManager.CurrentEnemy);
                    if (img != null)
                    {
                        pictureslime.BackgroundImage = img;
                        pictureslime.BackgroundImageLayout = ImageLayout.Stretch;
                    }

                    // =========================================================
                    // ★追加：次の敵（魔王など）が出現した「瞬間」に背景も切り替える！
                    // =========================================================
                    await ChangeBackgroundImage(stageManager.CurrentEnemy);

                    await DisplayCurrentEnemy();
                    // ヒントが表示されてからバトルに遷移するための猶予
                    await Task.Delay(3000);
                    // ループして次のバトルへ
                }
                else
                {
                    // 予期しない状態ならループを抜ける
                    break; // ★修正：「break;あ」のミスを修正しました
                }
            }
        }

        private void labelencount_Click(object sender, EventArgs e)
        {

        }
    }
}


