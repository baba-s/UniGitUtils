﻿using System;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace UniGitUtils
{
	/// <summary>
	/// Git に関するメニューを管理するクラス
	/// </summary>
	public static class GitUtilsMenu
	{
		//================================================================================
		// 定数
		//================================================================================
		public const string ITEM_NAME_ROOT = "Edit/UniGitUtils/"; // Unity メニューのルート

		//================================================================================
		// イベント（static）
		//================================================================================
		/// <summary>
		/// <para>Unity メニューからスクリプトを生成する時に呼び出される関数</para>
		/// <para>Unity メニューからスクリプトを生成する処理を外部から登録できます</para>
		/// </summary>
		public static event Action OnForceGenerate;

		//================================================================================
		// 関数（static）
		//================================================================================
		/// <summary>
		/// Unity メニューからスクリプトを生成するための関数
		/// </summary>
#if KOGANE_ENGLISH
		[MenuItem( ITEM_NAME_ROOT + "Generate Git Constants" )]
#else
		[MenuItem( ITEM_NAME_ROOT + "Git の情報を管理するスクリプトを生成" )]
#endif
		private static void ForceGenerate()
		{
			if ( OnForceGenerate == null )
			{
				if ( Application.systemLanguage == SystemLanguage.Japanese )
				{
					Debug.LogWarning( "[UniGitUtils] Git の情報を管理するスクリプトを生成する処理が登録されていません" );
				}
				else
				{
					Debug.LogWarning( "[UniGitUtils] No function to generate Git constants has been registered" );
				}
				return;
			}

			OnForceGenerate();
		}

		/// <summary>
		/// Unity メニューからブランチ名をログ出力して確認するための関数
		/// </summary>
#if KOGANE_ENGLISH
		[MenuItem( ITEM_NAME_ROOT + "Branch/Log to Console" )]
#else
		[MenuItem( ITEM_NAME_ROOT + "ブランチ名/ログ出力" )]
#endif
		private static void LogBranchName()
		{
			Debug.Log( $"[UniGitUtils] {GitUtils.LoadBranchName()}" );
		}

		/// <summary>
		/// Unity メニューからブランチ名をクリップボードにコピーするための関数
		/// </summary>
#if KOGANE_ENGLISH
		[MenuItem( ITEM_NAME_ROOT + "Branch/Copy to Clipboard" )]
#else
		[MenuItem( ITEM_NAME_ROOT + "ブランチ名/クリップボードにコピー" )]
#endif
		private static void CopyBranchName()
		{
			GUIUtility.systemCopyBuffer = GitUtils.LoadBranchName();
		}

		/// <summary>
		/// Unity メニューからコミットハッシュをログ出力して確認するための関数
		/// </summary>
#if KOGANE_ENGLISH
		[MenuItem( ITEM_NAME_ROOT + "Commit Hash/Log to Console" )]
#else
		[MenuItem( ITEM_NAME_ROOT + "コミットハッシュ/ログ出力" )]
#endif
		private static void LogCommitHash()
		{
			Debug.Log( $"[UniGitUtils] {GitUtils.LoadCommitHash()}" );
		}

		/// <summary>
		/// Unity メニューからコミットハッシュをクリップボードにコピーして確認するための関数
		/// </summary>
#if KOGANE_ENGLISH
		[MenuItem( ITEM_NAME_ROOT + "Commit Hash/Copy to Clipboard" )]
#else
		[MenuItem( ITEM_NAME_ROOT + "コミットハッシュ/クリップボードにコピー" )]
#endif
		private static void CopyCommitHash()
		{
			GUIUtility.systemCopyBuffer = GitUtils.LoadCommitHash();
		}

		/// <summary>
		/// Unity メニューからコミットハッシュ（短縮版）をログ出力して確認するための関数
		/// </summary>
#if KOGANE_ENGLISH
		[MenuItem( ITEM_NAME_ROOT + "Commit Hash (Shortened)/Log to Console" )]
#else
		[MenuItem( ITEM_NAME_ROOT + "コミットハッシュ（短縮版）/ログ出力" )]
#endif
		private static void LogShortCommitHash()
		{
			Debug.Log( $"[UniGitUtils] {GitUtils.LoadShortCommitHash()}" );
		}

		/// <summary>
		/// Unity メニューからコミットハッシュ（短縮版）をクリップボードにコピーして確認するための関数
		/// </summary>
#if KOGANE_ENGLISH
		[MenuItem( ITEM_NAME_ROOT + "Commit Hash (Shortened)/Copy to Clipboard" )]
#else
		[MenuItem( ITEM_NAME_ROOT + "コミットハッシュ（短縮版）/クリップボードにコピー" )]
#endif
		private static void CopyShortCommitHash()
		{
			GUIUtility.systemCopyBuffer = GitUtils.LoadShortCommitHash();
		}

		/// <summary>
		/// Unity メニューからコミットログをログ出力して確認するための関数
		/// </summary>
#if KOGANE_ENGLISH
		[MenuItem( ITEM_NAME_ROOT + "Commit Log/Log to Console" )]
#else
		[MenuItem( ITEM_NAME_ROOT + "コミットログ/ログ出力" )]
#endif
		private static void LogCommitLog()
		{
			var option = new CommitLogOption
			(
				count: 10,
				isNoMerges: false,
				format: "%h %cd %cn %s"
			);

			Debug.Log( $"[UniGitUtils]\n{GitUtils.LoadCommitLog( option )}" );
		}

		/// <summary>
		/// Unity メニューからコミットログをクリップボードにコピーして確認するための関数
		/// </summary>
#if KOGANE_ENGLISH
		[MenuItem( ITEM_NAME_ROOT + "Commit Log/Copy to Clipboard" )]
#else
		[MenuItem( ITEM_NAME_ROOT + "コミットログ/クリップボードにコピー" )]
#endif
		private static void CopyCommitLog()
		{
			var option = new CommitLogOption
			(
				count: 10,
				isNoMerges: false,
				format: "%h %cd %cn %s"
			);
			
			GUIUtility.systemCopyBuffer = GitUtils.LoadCommitLog( option );
		}
	}
}