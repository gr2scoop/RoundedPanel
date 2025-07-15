# 🟦 RoundedShadowPanel

WinForms에서 모던한 UI를 위해 둥근 모서리와 그림자가 적용된 커스텀 `Panel`입니다.

## ✨ 특징

- 그림자와 둥근 모서리를 자동으로 렌더링
- 배경색(FillColor), 그림자색(ShadowColor), 둥글기(CornerRadius) 등을 자유롭게 설정 가능
- 내부 여백(InnerPadding)으로 콘텐츠 여유 공간 확보
- `AutoSize = true` 지원

## 🧪 샘플 코드

```csharp
var panel = new RoundedShadowPanel
{
    CornerRadius = 20,
    ShadowSize = 10,
    ShadowColor = Color.FromArgb(80, 0, 0, 0),
    FillColor = Color.White,
    InnerPadding = new Padding(10)
};

var label = new Label
{
    Text = "Hello Rounded Panel!",
    AutoSize = true
};

panel.Controls.Add(label);
this.Controls.Add(panel);
```

## ⚙️ 주요 속성

| 속성명         | 설명 |
|----------------|------|
| `CornerRadius` | 모서리 둥글기 (기본값: `16`) |
| `ShadowSize`   | 그림자 크기 (기본값: `15`) |
| `ShadowColor`  | 그림자 색상 (`ARGB` 사용 가능) |
| `FillColor`    | 패널 내부 배경색 |
| `InnerPadding` | 내부 콘텐츠 여백 |

## 🧩 레이아웃 팁

- 여러 개의 패널을 배치할 땐 `TableLayoutPanel`이나 `FlowLayoutPanel`과 함께 사용하세요.
- `Dock = DockStyle.Top`을 기본으로 설정하여 위에서 아래로 정렬되는 구조에 적합합니다.

## 🖥 데모 실행법

### ✅ 요구 사항

- .NET Framework 4.8 이상
- Visual Studio 2019 또는 2022
- `RoundedPanelDemo.sln` 솔루션 파일을 열어서 빌드/실행

### 📁 주요 파일 설명

| 파일명 | 설명 |
|--------|------|
| `RoundedPanelDemo.sln` | Visual Studio 솔루션 파일 |
| `Form1.cs` | 데모 UI가 구성된 메인 폼 |
| `RoundedShadowPanel.cs` | 둥근 그림자 패널 컨트롤 소스 |
| `Program.cs` | WinForms 진입점 |
| `Resources.resx` | 리소스 설정 파일 (아이콘, 문자열 등) |
| `RoundedPanelDemo.exe` | 빌드된 실행 파일 (Windows Forms 앱) |

## 🖼️ 데모 스크린샷

![RoundedShadowPanel Demo](/assets/screenshot.png)

## 🧪 RoundedPanelDemo 예제

이 예제는 `RoundedShadowPanel`을 이용해 다음과 같은 요소를 시각적으로 보여줍니다:

- 둥근 모서리와 그림자가 적용된 배경
- 내부에 배치된 텍스트 레이블
- 전체 폼 내 자동 크기 조절 (`AutoSize`) 및 여백 (`InnerPadding`) 반영
- `TableLayoutPanel`을 활용한 깔끔한 정렬 구조

해당 예제는 `Form1.cs` 내에서 구성되어 있으며, 실행 시 자동으로 `RoundedShadowPanel`이 포함된 UI가 표시됩니다.