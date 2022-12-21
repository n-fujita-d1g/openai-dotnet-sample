# openai-dotnet-sample
OpenAI APIを.Netから使うサンプル

## 設定

1. OpenAIにサインアップ（Googleアカウント等）
   - https://chat.openai.com/
2. OpenAIのAPIキーを取得
   - https://beta.openai.com/account/api-keys
   - 取得したキーは秘匿する
   - 組織は「Personal」
3. .Net Coreでwebapiを作成(済み)
   - `dotnet install package OpenAI`
   - https://github.com/OkGoDoIt/OpenAI-API-dotnet
   - 公式ではなさげ
4. APIキー設定ファイルを配置
   - プロジェクトフォルダに「.openai」ファイルを作成→自動的に読み込まれる
   - `OPENAI_KEY=sk-NNNNNNNNNNN….` を記入
   - .openapi_templateを改名コピーして使ってください。

