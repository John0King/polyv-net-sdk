# polyv-net-sdk
保利威视 .net standard SDK

## Nuget包

暂未发布到Nuget

## API支持

- [x] 获取视频列表
- [x] 根据视频Id获取视频
- [x] 删除视频
- [ ] 上传视频
  - [ ] 断点续传 
- [ ] 其他Api占位符

## Framework Support

- [x] .Net standard 2.0
  - [x] .Net Framework 4.6.1 +
  - [x] Mono 5.4 +
- [ ] .Net standard 1.3
  - [ ] .Net Framework 4.6 +
  - [ ] Mono 4.6 +
- [ ] .Net standard 1.1
  - [ ] .Net Framework 4.5 +
  - [ ] Mono 4.6 +

本项目现在以 `netstandard2.0` 为目标，支持 .net framework 4.61+ 和 mono 5.4+  
当项目完成以后，我们会另外对 `netstandard1.3` 甚至 `netstandard1.1` 支持，
这将能进一步将支持的 .net framework 版本降低至 .net framework 4.5。

> 因为 `async/await` 的支持从 .net framework 4.5开始，我们不再支持较低的版本

